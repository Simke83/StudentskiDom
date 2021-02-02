use StudentskiDom

-- dodavanje soba
insert into sobe(sprat,maksBrojStanara,pol)
values(1,2,'M'),(1,2,'M'),(1,3,'Z'),(2,2,'Z'),(2,1,'M'),(2,3,'M'),(3,3,'Z');

-- dodavanje studenata sa sobama
insert into studenti(ime,prezime,godRodjenja,pol,idSobe)
values('Pera','Peric',1999,'M',1),('Marija','Marijic',2001,'Z',3),('Sima','Simic',2003,'M',1),('Marina','Marinkov',1998,'Z',3),('Nikola','Nikolic',1999,'M',5),('Jovana','Jovanovic',2001,'Z',7);


-- dodavanje studenata koji nemaju sobu--
insert into studenti(ime,prezime,godRodjenja,pol)
values('Sara','Saric',2000,'Z'),('Goran','Pesic',1999,'M');

insert into studenti(ime,prezime,godRodjenja,pol)
values('Milos','Simic',1993,'M'),('Teodora','Vidic',2003,'Z');

insert into studenti(ime,prezime,godRodjenja,pol)
values('Goran','Simic',1999,'M'),('Dragan','Masic',1998,'M');

insert into studenti(ime,prezime,godRodjenja,pol)
values('Masa','Masovic',2004,'Z');