using ProjekatStudentskiDom.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.DAO
{
    class SobaDAO
    {
        public static List<Soba> GetAll(SqlConnection conn)
        {
            List<Soba> listaSoba = new List<Soba>();

            try
            {
                string selectQuery = "select * from sobe";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader[0];
                    int sprat = (int)reader[1];
                    int maksBrojStanara = (int)reader[2];
                    char pol = Convert.ToChar(reader[3]);

                    Soba soba = new Soba(id, sprat, maksBrojStanara, pol);
                    string selectStudenteUSobi = "select * from studenti where idSobe=@idSobe";
                    SqlCommand cmd2 = new SqlCommand(selectStudenteUSobi, conn);

                    cmd2.Parameters.AddWithValue("@idSobe", soba.Id);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        int idStudenta = (int)reader2[0];
                        string ime = reader2[1].ToString();
                        string prezime = reader2[2].ToString();
                        int godRodjenja = (int)reader2[3];
                        char polStudenta = Convert.ToChar(reader2[4]);

                        Student student = new Student(idStudenta, ime, prezime, godRodjenja, polStudenta);

                        soba.ListaStudenataStanara.Add(student);
                    }
                    reader2.Close();

                    listaSoba.Add(soba);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nesto nije u redu sa bazom podataka! Opis greske: " + ex.Message);
            }

            return listaSoba;
        }
        public static Soba GetSobaByIdAll(SqlConnection conn, int id)
        {
            Soba soba = null;
            try
            {
                string selectQuery = $"select * from sobe where id={id}";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idSobe = (int)reader[0];
                    int sprat = (int)reader[1];
                    int maksBrojStanara = (int)reader[2];
                    char pol = Convert.ToChar(reader[3]);

                    soba = new Soba(idSobe, sprat, maksBrojStanara, pol);

                    string selectStudenteUSobi = "select * from studenti where idSobe=@idSobe";
                    SqlCommand cmd2 = new SqlCommand(selectStudenteUSobi, conn);
                    cmd2.Parameters.AddWithValue("@idSobe", idSobe);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        int idStudenta = (int)reader2[0];
                        string ime = reader2[1].ToString();
                        string prezime = reader2[2].ToString();
                        int godRodjenja = (int)reader2[3];
                        char polStudenta = Convert.ToChar(reader2[4]);

                        Student student = new Student(idStudenta, ime, prezime, godRodjenja, polStudenta);

                        soba.ListaStudenataStanara.Add(student);
                    }
                    reader2.Close();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nesto nije u redu sa bazom podataka! Opis greske: " + ex.Message);
            }

            return soba;
        }
        public static Soba GetSobaById(SqlConnection conn, int id)
        {
            Soba soba = null;
            try
            {
                string selectQuery = $"select * from sobe where id={id}";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idSobe = (int)reader[0];
                    int sprat = (int)reader[1];
                    int maksBrojStanara = (int)reader[2];
                    char pol = Convert.ToChar(reader[3]);

                    soba = new Soba(idSobe, sprat, maksBrojStanara, pol);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nesto nije u redu sa bazom podataka! Opis greske: " + ex.Message);
            }

            return soba;
        }
    }
}
