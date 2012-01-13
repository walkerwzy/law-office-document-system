alter table sysuser add pycode varchar(50);
alter table contract add username varchar(50);

alter table cate_cust add deptid int;
alter table cate_case add prefix char(1) default 'A';
alter table cate_cust add prefix char(1) default 'K';

--9/10
alter table customer add ownerbirth datetime;
alter table customer add lunar1 tinyint default 0;
alter table customer add chargebirth datetime;
alter table customer add lunar2 tinyint default 0;
alter table contract add c_ctime datetime;
create table office (
   zongzhi              ntext                null,
   zhanlue              ntext                null,
   zhidu                ntext                null,
   bak1                 ntext                null,
   bak2                 ntext                null,
   bak3                 ntext                null
)
go
insert into office values('','','','','','');
go
create table alert (
   uid                  int                  null,
   cont                 ntext                null,
   alerttime            datetime             null,
   isprivate            tinyint              null default 0
)
go
--9/16
alter table customer add custno varchar(20);
declare @i int
set @i=1
while @i<10
begin
update customer set custno='E1100'+CAST(@i as varchar) where custid=@i
set @i=@i+1
end

--declare @i int
--set @i=10
--while @i<36--请修改此值
--begin
--update customer set custno='E110'+CAST(@i as varchar) where custid=@i
--set @i=@i+1
--end

alter table customer add recno int;

declare @i int
set @i=1
while @i<37--行数
begin
update customer set recno=@i where custid=@i
set @i=@i+1
end

----9/26----
create table entry (
   eid                  int                  identity,
   uid                  int                  null,
   etype                varchar(20)          null,
   etitle               nvarchar(50)         null,
   econt                ntext                null,
   createdate           datetime             null,
   modifydate           datetime             null,
   constraint PK_ENTRY primary key (eid)
)
go

---1101---

if exists (select 1
            from  sysobjects
           where  id = object_id('employee')
            and   type = 'U')
   drop table employee
go

/*==============================================================*/
/* Table: employee                                              */
/*==============================================================*/
create table employee (
   uid                  int                  null,
   cert                 varchar(50)          null,
   gender               tinyint              null,
   nation               varchar(50)          null,
   birthday             datetime             null,
   hukou                varchar(50)          null,
   family               nvarchar(255)        null,
   intime               datetime             null,
   formtime             datetime             null,
   summary              nvarchar(2000)       null,
   remark               nvarchar(2000)       null,
   photo                varchar(100)         null,
   baoxian              datetime             null,
   lizhi                datetime             null
)
go


--给用户表添加执业号字段
-- alter table sysuser add certno varchar(50);
-- go
-- alter table 
--给客户表添加联系人，联系人电话字段
alter table customer add contact nvarchar(20);
go
alter table customer add contel varchar(50);
go
--给案件表添加审理法院
alter table cases add court nvarchar(50);
go

--12/7
--重大事件表加主键
if exists (select 1
            from  sysobjects
           where  id = object_id('alert')
            and   type = 'U')
   drop table alert
go

/*==============================================================*/
/* Table: alert                                                 */
/*==============================================================*/
create table alert (
   id                   bigint               identity,
   uid                  int                  null,
   cont                 ntext                null,
   alerttime            datetime             null,
   isprivate            tinyint              null default 0,
   constraint PK_ALERT primary key (id)
)
go

15871719845 蒋