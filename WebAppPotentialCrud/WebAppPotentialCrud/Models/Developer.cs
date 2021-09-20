using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPotentialCrud.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
        public string Hobby { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
