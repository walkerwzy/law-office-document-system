--2/24
--Ϊ�ĵ������ҵ�����͵���
alter table docs add typeid int;
go
update docs set typeid=0;
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
           where  id = object_id('yuwudoc')
            and   type = 'U')
   drop table yuwudoc
go

/*==============================================================*/
/* Table: yuwudoc                                               */
/*==============================================================*/
create table yuwudoc (
   recid                int                  identity,
   cate_id              tinyint              null,
   cateid               int                  null,
   constraint PK_YUWUDOC primary key (recid)
)
go
