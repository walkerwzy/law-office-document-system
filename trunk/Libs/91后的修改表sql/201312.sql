--添加结案选项（结案状态/结案日期/结案人）
--结案为最终状态，所以不用关联表，存成如下字段：{user:'张三',time:'2013-06-07 13:27:35'}
alter table cases add caseclosed nvarchar(100) default null;
go
