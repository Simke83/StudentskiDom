using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.Models
{
    class Soba
    {
        public int Id { get; set; }

        public int Sprat { get; set; }

        public int MaksBrojStanara { get; set; }

        public char Pol { get; set; }

        public List<Student> ListaStudenataStanara { get; set; }

        public Soba(int id, int sprat, int maksBrojStanara, char pol)
        {
            this.Id = id;
            this.Sprat = sprat;
            this.MaksBrojStanara = maksBrojStanara;
            this.Pol = pol;
            ListaStudenataStanara = new List<Student>();
        }
        public override string ToString()
        {
            return String.Format("ID: {0} | Sprat: {1} | Pol za sobu: {2} | Trenutni broj stanara: {3} | Maks. broj stanara: {4}",this.Id,this.Sprat,this.Pol,this.ListaStudenataStanara.Count,this.MaksBrojStanara);
        }
    }
}
