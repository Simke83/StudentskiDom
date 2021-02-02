using ProjekatStudentskiDom.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.DAO
{
    class StudentDAO
    {
        public static List<Student> GetAll(SqlConnection conn)
        {
            List<Student> listaStudenata = new List<Student>();
            try
            {
                string selectQuery = "select * from studenti";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader[0];
                    string ime = reader[1].ToString();
                    string prezime = reader[2].ToString();
                    int godRodjenja = (int)reader[3];
                    char pol = Convert.ToChar(reader[4]);
                    int idSobe;

                    Student student = new Student(id, ime, prezime, godRodjenja, pol);
                    if (int.TryParse(reader[5].ToString(), out idSobe))
                    {
                        Soba soba = SobaDAO.GetSobaById(conn, idSobe);
                        if (soba != null)
                        {
                            student.StudentSoba = soba;
                        }
                    }

                    listaStudenata.Add(student);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nesto nije u redu sa bazom podataka! Opis greske: " + ex.Message);
            }

            return listaStudenata;
        }

        public static Student GetStudentById(SqlConnection conn, int id)
        {
            Student student = null;
            try
            {
                string selectQuery = $"select * from studenti where id={id}";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idStudenta = (int)reader[0];
                    string ime = reader[1].ToString();
                    string prezime = reader[2].ToString();
                    int godRodjenja = (int)reader[3];
                    char pol = Convert.ToChar(reader[4]);
                    student = new Student(id, ime, prezime, godRodjenja, pol);

                    int idSobe;
                    if (int.TryParse(reader[5].ToString(), out idSobe))
                    {
                        Soba soba = SobaDAO.GetSobaById(conn, idSobe);
                        if (soba != null)
                        {
                            student.StudentSoba = soba;
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nesto nije u redu sa bazom podataka! Opis greske: " + ex.Message);
            }
            return student;
        }
        public static bool AddStudentUSobu(SqlConnection conn, Student student, Soba soba)
        {
            bool isAdded = false;
            try
            {
                string updateQuery = "update studenti set idSobe=@idSobe where id=@idStudenta";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@idSobe", soba.Id);
                cmd.Parameters.AddWithValue("@idStudenta", student.Id);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    isAdded = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nesto nije u redu sa bazom podataka! Opis greske: " + ex.Message);
            }

            return isAdded;
        }
    }
}
