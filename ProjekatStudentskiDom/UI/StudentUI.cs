using ProjekatStudentskiDom.DAO;
using ProjekatStudentskiDom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.UI
{
    class StudentUI
    {
        public static void IspisiSveStudente()
        {
            List<Student> listaStudenata = StudentDAO.GetAll(Program.conn);
            if (listaStudenata.Count > 0)
            {
                listaStudenata.ForEach(x => Console.WriteLine(x));
            }
        }
        public static void IspisStudenataSaSobama()
        {
            List<Student> listaStudenata = StudentDAO.GetAll(Program.conn);
            if (listaStudenata.Count > 0)
            {
                foreach (Student s in listaStudenata)
                {
                    s.IspisStudentaSaSobom();
                }
            }
        }
    }
}
