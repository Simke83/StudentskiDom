using ProjekatStudentskiDom.DAO;
using ProjekatStudentskiDom.Models;
using ProjekatStudentskiDom.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.UI
{
    class SobaUI
    {
        public static void IspisiSveSobe()
        {
            List<Soba> listaSoba = SobaDAO.GetAll(Program.conn);

            if (listaSoba.Count > 0)
            {
                listaSoba.ForEach(x => Console.WriteLine(x));
            }
        }

        public static void DodajPostojecegStudentaUPostojecuSobu()
        {
            Console.WriteLine("Studenti sa informacijom o sobi:");
            Console.WriteLine("-------------------------------------------------------------");
            StudentUI.IspisStudenataSaSobama();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Unesite ID studenta kojeg zelite da dodate u odredjenu sobu: ");
            int idStudenta = IO.OcitajCeoBroj();

            Student student = StudentDAO.GetStudentById(Program.conn, idStudenta);
            if (student != null)
            {
                if (ProveraDaLiStudentVecImaSobu(student) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Sobe:");
                    Console.WriteLine("-------------------------------------------------------------");
                    SobaUI.IspisiSveSobe();
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("Unesite ID sobe u koju zelite da dodate {0} {1}: ",student.Ime,student.Prezime);
                    int idSobe = IO.OcitajCeoBroj();
                    Soba soba = SobaDAO.GetSobaByIdAll(Program.conn, idSobe);
                    if (soba != null)
                    {
                        if (ProveraDaLiSobaImaDovoljnoMesta(soba))
                        {
                            if (ProveraDaLiJeStudentOdgovarajucegPolaZaSobu(student, soba))
                            {
                                if (StudentDAO.AddStudentUSobu(Program.conn, student, soba))
                                {
                                    Console.WriteLine("Uspesno ste dodali studenta u sobu!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Zao mi je, studenti razlicitog pola ne mogu stanovati zajedno!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Zao mi je, u ovoj sobi nema dovoljno mesta!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Soba sa unetim ID-om nije pronadjena!");
                    }
                }
                else
                {
                    Console.WriteLine("Greska, student sa unetim ID-om vec ima sobu!");
                }
            }
            else
            {
                Console.WriteLine("Student sa unetim ID-om nije pronadjen!");
            }
        }

        private static bool ProveraDaLiStudentVecImaSobu(Student student)
        {
            if (student.StudentSoba == null)
            {
                return false;
            }
            else 
            {
                return true;
            } 
        }

        private static bool ProveraDaLiSobaImaDovoljnoMesta(Soba soba)
        {
            if (soba.ListaStudenataStanara.Count >= soba.MaksBrojStanara)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool ProveraDaLiJeStudentOdgovarajucegPolaZaSobu(Student student, Soba soba)
        {
            if (student.Pol == soba.Pol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
