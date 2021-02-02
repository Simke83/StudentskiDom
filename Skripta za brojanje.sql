use StudentskiDom
--broj praznih soba grupisani po polu

select pol,sum(case when idSobe is null then 1 else 0 end) broj_praznih_soba from studenti  group by pol 