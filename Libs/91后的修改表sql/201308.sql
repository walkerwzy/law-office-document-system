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
