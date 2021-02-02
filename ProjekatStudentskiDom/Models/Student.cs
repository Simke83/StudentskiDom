using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.Models
{
    class Student
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int GodinaRodjenja { get; set; }
        public char Pol { get; set; }

        public Soba StudentSoba { get; set; }

        public Student(int id, string ime, string prezime, int godinaRodjenja, char pol)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.GodinaRodjenja = godinaRodjenja;
            this.Pol = pol;
            StudentSoba = null;
        }

        public override string ToString()
        {
            return string.Format("ID: {0} | Ime i prezime: {1} {2} | Godina rodjenja: {3} | Pol: {4}", this.Id, this.Ime, this.Prezime, this.GodinaRodjenja, this.Pol);
        }
        public void IspisStudentaSaSobom()
        {
            string soba;
            if (StudentSoba != null)
            {
                soba = $"Stanuje u sobi br: {StudentSoba.Id}";
            }
            else
            {
                soba = "Nema sobu!";
            }
            Console.WriteLine("ID: {0} | Ime i prezime: {1} {2} | Godina rodjenja: {3} | Pol: {4} | {5}",this.Id,this.Ime,this.Prezime,this.GodinaRodjenja,this.Pol,soba);

        }
    }
}
