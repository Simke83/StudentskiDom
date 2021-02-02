using ProjekatStudentskiDom.UI;
using ProjekatStudentskiDom.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom
{
    class Program
    {
        public static SqlConnection conn;

        static void LoadConnection()
        {
            try
            {
                const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentskiDom;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True";
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Doslo je do greske pri konekciji sa bazom! Opis: " + ex.Message);
            }
        }
        static void Main(string[] args)
        {
            LoadConnection();
            Meni();
            conn.Close();

        }
        public static void IspisiMenu()
        {
            Console.WriteLine("Studentski Dom - Osnovne opcije:");
            Console.WriteLine("\tOpcija broj 1 - prikaz svih soba u sistemu");
            Console.WriteLine("\tOpcija broj 2 - prikaz svih studenata u sistemu");
            Console.WriteLine("\tOpcija broj 3 - prikaz svih studenata zajedno sa sobom u kojoj se nalaze");
            Console.WriteLine("\tOpcija broj 4 - dodaj postojeceg studenta u postojecu sobu");
            Console.WriteLine("\tOpcija broj 5 - ispisi izvestaj o svim sobama u sistemu kao PDF");



            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija broj 0 - IZLAZ IZ PROGRAMA");
        }
        public static void Meni()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiMenu();
                Console.Write("Opcija:");
                odluka = IO.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz");
                        break;
                    case 1:
                        SobaUI.IspisiSveSobe();
                        break;
                    case 2:
                        StudentUI.IspisiSveStudente();
                        break;
                    case 3:
                        StudentUI.IspisStudenataSaSobama();
                        break;
                    case 4:
                        SobaUI.DodajPostojecegStudentaUPostojecuSobu();
                        break;
                    case 5:
                        ToPDF.IzvestajPDF.DodajDokument();
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda!\n\n");
                        break;
                }
            }
        }
    }
}
