--7/29======
--��������� Э����ʦ����֤����
alter table cases add xieban int;
go
alter table cases add juzheng datetime;
go

--7/30==============
--��Ӱ��������ĵ�����
SET IDENTITY_INSERT [cate_doc] ON
insert into cate_doc(cateid,catename,seq) values(18,'���������ļ�',7);
go
SET IDENTITY_INSERT [cate_doc] OFF

--7/31===============
--���ҵ������嵥��tasklog
if exists (select 1
            from  sysobjects
           where  id = object_id('tasklog')
            and   type = 'U')
   drop table tasklog
go

/*==============================================================*/
/* Table: tasklog                                               */
/*==============================================================*/
create table tasklog (
   recid                int                  identity,
   rectime              datetime             null,
   expiretime           datetime             null,
   custid               int                  null,
   userid               int                  null,
   agentid              int                  null,
   tasklist             ntext                null,
   footlist             ntext                null,
   feedback             ntext                null,
   constraint PK_TASKLOG primary key (recid)
)
go

