using Microsoft.EntityFrameworkCore;
using PotentialCrud.Model;
using PotentialCrud.Model.Developers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotentialCrud.Repository.Developers
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly ContextoAplicacao contexto;
        public DeveloperRepository(ContextoAplicacao contexto)
        {
            this.contexto = contexto;
        }

        public IEnumerable<Developer> ListarDevelopers()
        {
            return contexto.Developers.ToList();
        }

        public Developer ObterDeveloper(int id)
        {
            var developer = contexto.Developers.FirstOrDefault(x => x.Id == id);

            if (developer == null)
                throw new ArgumentNullException("Developer não encontrado");

            return developer;
        }


        public int IncluirDeveloper(Developer developer)
        {            
            contexto.Developers.Add(developer);
            contexto.SaveChanges();
            return developer.Id;
        }

        public void AlterarDeveloper(Developer developer, int id)
        {
            if (developer.Id != id)
                throw new ArgumentException("O Id não pertence ao desenvolvedor informado");

            contexto.Entry(developer).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void DeletarDeveloper(int id)
        {
            var developer = contexto.Developers.FirstOrDefault(x => x.Id == id);

            if (developer == null)
                throw new ArgumentException("Desenvolvedor não encontrado");

            contexto.Developers.Remove(developer);
            contexto.SaveChanges();            
        }
    }
}
