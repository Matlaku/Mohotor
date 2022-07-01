use annie
go

create table POP(
PopID int not null,
address varchar(255) not null,
Name varchar(255) not null,
availability bit
);

insert into POP
values (01,'52 Bangay road Montclair','Anelang',1),
(02,'26 edgewood ave','Nhlakanipho',1),
(03,'78 gravy lane', 'Zama',0),
(04,'49 grove lane','Sanele',1);

select * from POP;

select PopID from POP where availability = 1;

