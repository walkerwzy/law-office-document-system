--7/29======
--案件表添加 协办律师，举证期限
alter table cases add xieban int;
go
alter table cases add juzheng datetime;
go

--7/30==============
--添加案件附加文档类型
SET IDENTITY_INSERT [cate_doc] ON
insert into cate_doc(cateid,catename,seq) values(18,'案件附加文件',7);
go
SET IDENTITY_INSERT [cate_doc] OFF
