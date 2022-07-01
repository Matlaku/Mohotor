use annie
go

create table POP(
PopID int identity(1,1) primary key,
address varchar(255) not null,
Name varchar(255) not null,
availability bit
);

insert into POP
values ('52 Bangay road Montclair','Anelang',1),
('26 edgewood ave','Nhlakanipho',1),
('78 gravy lane', 'Zama',1),
('49 grove lane','Sanele',1);

select * from POP;

select PopID from POP where availability = 1;

select Name, address from POP

update POP set availability = 0 where PopID = 1

drop table POP