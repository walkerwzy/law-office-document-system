--2/24
--Ϊ������������ĵ�����
alter table cases add tiwen int;
go
alter table cases add dabian int;
go

--Ϊ�ĵ������ҵ�����͵���
alter table docs add typeid int;
go

--���ҵ�����ͱ�
if exists (select 1
            from  sysobjects
           where  id = object_id('cate_yewu')
            and   type = 'U')
   drop table cate_yewu
go

/*==============================================================*/
/* Table: cate_yewu                                             */
/*==============================================================*/
create table cate_yewu (
   cate_id              tinyint              identity,
   cate_name            varchar(20)          null,
   cate_index           tinyint              null,
   cate_remark          varchar(100)         null,
   constraint PK_CATE_YEWU primary key (cate_id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ҵ������ҵ��ר������',
   'user', @CurrentUser, 'table', 'cate_yewu'
go

insert into cate_yewu (cate_name,cate_index) values('����ҵ��','1');
insert into cate_yewu (cate_name,cate_index) values('����ҵ��','2');
insert into cate_yewu (cate_name,cate_index) values('ר�����','3');
go

--���ҵ������-�ĵ����͹�����
if exists (select 1
            from  sysobjects
           where  id = object_id('yewudoc')
            and   type = 'U')
   drop table yewudoc
go

/*==============================================================*/
/* Table: yewudoc                                               */
/*==============================================================*/
create table yewudoc (
   recid                int                  identity,
   typeid              tinyint              null,
   cateid               int                  null,
   constraint PK_YEWUDOC primary key (recid)
)
go

--===============�ṹ�޸ĺ��ʼ������============

--�޸��ĵ����ͱ��ʼ����
delete from cate_doc where cateid > 6;
go
SET IDENTITY_INSERT [cate_doc] ON
insert into cate_doc(cateid,catename,seq) values(7,'�����ƶ�',4);
insert into cate_doc(cateid,catename,seq) values(8,'����',1);
insert into cate_doc(cateid,catename,seq) values(9,'Э��',2);
insert into cate_doc (cateid,catename,seq) values(10,'����״/����״',1);
insert into cate_doc (cateid,catename,seq) values(11,'֤��Ŀ¼',2);
insert into cate_doc (cateid,catename,seq) values(12,'��֤���',3);
insert into cate_doc (cateid,catename,seq) values(13,'��ͥ����',4);
insert into cate_doc (cateid,catename,seq) values(14,'�������',5);
insert into cate_doc (cateid,catename,seq) values(15,'������',6);
insert into cate_doc (cateid,catename,seq) values(16,'�ݷü�¼',6);
insert into cate_doc (cateid,catename,seq) values(17,'ԭʼ����',7);
go
update cate_doc set seq=1 where cateid=4
update cate_doc set seq=2 where cateid=3
update cate_doc set seq=3 where cateid=5
update cate_doc set seq=5 where cateid=1
update cate_doc set seq=3 where cateid=6
update cate_doc set seq=4 where cateid=2
go
SET IDENTITY_INSERT [cate_doc] OFF
--��ʼ��ҵ������-�ĵ����͹�����
insert into yewudoc (typeid,cateid) values (1,4);
insert into yewudoc (typeid,cateid) values (1,3);
insert into yewudoc (typeid,cateid) values (1,5);
insert into yewudoc (typeid,cateid) values (1,7);
insert into yewudoc (typeid,cateid) values (1,1);
insert into yewudoc (typeid,cateid) values (1,16);
insert into yewudoc (typeid,cateid) values (1,17);
insert into yewudoc (typeid,cateid) values (2,10);
insert into yewudoc (typeid,cateid) values (2,11);
insert into yewudoc (typeid,cateid) values (2,12);
insert into yewudoc (typeid,cateid) values (2,13);
insert into yewudoc (typeid,cateid) values (2,14);
insert into yewudoc (typeid,cateid) values (2,15);
insert into yewudoc (typeid,cateid) values (3,8);
insert into yewudoc (typeid,cateid) values (3,9);
insert into yewudoc (typeid,cateid) values (3,6);
insert into yewudoc (typeid,cateid) values (3,2);
go

--�޸�doc�������cateid��typeid
--step1 ���������������ù����ĵ����6���ϵĶ�Ҫ����
--����8��9��10��11
update docs set typeid=1, cateid=7 where cateid=9;
update docs set typeid=1, cateid=16 where cateid in (8,10);
update docs set typeid=1, cateid=17 where cateid=11;
go
--step2
--�ӹ�����������ȷ��ҵ��ID���ǰ������
update docs set typeid=(select top 1 typeid from yewudoc where yewudoc.cateid=docs.cateid);
go
--step3
--�Ӱ��������ĵ���İ�������ĵ�
--����7
update docs set typeid=2, cateid=10 where docid in (select qisu from cases where qisu>0);
update docs set typeid=2, cateid=11 where docid in (select evidence from cases where evidence>0);
update docs set typeid=2, cateid=12 where docid in (select opinion from cases where opinion>0);
update docs set typeid=2, cateid=13 where docid in (select tiwen from cases where tiwen>0);
update docs set typeid=2, cateid=14 where docid in (select quote from cases where quote>0);
update docs set typeid=2, cateid=15 where docid in (select dabian from cases where dabian>0);
go
