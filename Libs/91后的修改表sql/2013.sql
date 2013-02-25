--2/24
--为文档表添加业务类型的列
alter table docs add typeid int;
go
update docs set typeid=0;
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
