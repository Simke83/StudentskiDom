create table sobe
(
id int primary key identity,
sprat int,
maksBrojStanara int,
pol char(1),
);



create table studenti
(
id int primary key identity,
ime nvarchar(50),
prezime nvarchar(50),
godRodjenja int,
pol char(1),
idSobe int,
foreign key(idSobe) references sobe(id)
);



