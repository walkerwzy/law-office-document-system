--2/24
--为案件添加两个文档类型
alter table cases add tiwen int;
go
alter table cases add dabian int;
go

--为文档表添加业务类型的列
alter table docs add typeid int;
go

--添加业务类型表
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
   '常年业务、诉讼业务、专项服务等',
   'user', @CurrentUser, 'table', 'cate_yewu'
go

insert into cate_yewu (cate_name,cate_index) values('常年业务','1');
insert into cate_yewu (cate_name,cate_index) values('诉讼业务','2');
insert into cate_yewu (cate_name,cate_index) values('专项服务','3');
go

--添加业务类型-文档类型关联表
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

--===============结构修改后初始化数据============

--修改文档类型表初始数据
delete from cate_doc where cateid > 6;
go
SET IDENTITY_INSERT [cate_doc] ON
insert into cate_doc(cateid,catename,seq) values(7,'规章制度',4);
insert into cate_doc(cateid,catename,seq) values(8,'方案',1);
insert into cate_doc(cateid,catename,seq) values(9,'协议',2);
insert into cate_doc (cateid,catename,seq) values(10,'起诉状/上诉状',1);
insert into cate_doc (cateid,catename,seq) values(11,'证据目录',2);
insert into cate_doc (cateid,catename,seq) values(12,'质证意见',3);
insert into cate_doc (cateid,catename,seq) values(13,'法庭提问',4);
insert into cate_doc (cateid,catename,seq) values(14,'代理意见',5);
insert into cate_doc (cateid,catename,seq) values(15,'答辩意见',6);
insert into cate_doc (cateid,catename,seq) values(16,'拜访记录',6);
insert into cate_doc (cateid,catename,seq) values(17,'原始资料',7);
go
update cate_doc set seq=1 where cateid=4
update cate_doc set seq=2 where cateid=3
update cate_doc set seq=3 where cateid=5
update cate_doc set seq=5 where cateid=1
update cate_doc set seq=3 where cateid=6
update cate_doc set seq=4 where cateid=2
go
SET IDENTITY_INSERT [cate_doc] OFF
--初始化业务类型-文档类型关联表
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

--修改doc表里面的cateid，typeid
--step1 处理他们自行设置过的文档类别，6以上的都要处理
--处理8，9，10，11
update docs set typeid=1, cateid=7 where cateid=9;
update docs set typeid=1, cateid=16 where cateid in (8,10);
update docs set typeid=1, cateid=17 where cateid=11;
go
--step2
--从关联表设置正确的业务ID（非案件类别）
update docs set typeid=(select top 1 typeid from yewudoc where yewudoc.cateid=docs.cateid);
go
--step3
--从案件表反设文档表的案件相关文档
--处理7
update docs set typeid=2, cateid=10 where docid in (select qisu from cases where qisu>0);
update docs set typeid=2, cateid=11 where docid in (select evidence from cases where evidence>0);
update docs set typeid=2, cateid=12 where docid in (select opinion from cases where opinion>0);
update docs set typeid=2, cateid=13 where docid in (select tiwen from cases where tiwen>0);
update docs set typeid=2, cateid=14 where docid in (select quote from cases where quote>0);
update docs set typeid=2, cateid=15 where docid in (select dabian from cases where dabian>0);
go
