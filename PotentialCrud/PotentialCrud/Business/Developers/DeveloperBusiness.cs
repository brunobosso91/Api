using PotentialCrud.Model.Developers;
using PotentialCrud.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotentialCrud.Business.Developers
{
    public class DeveloperBusiness : IDeveloperBusiness
    {
        private readonly IDeveloperRepository developerRepository;
        public DeveloperBusiness(IDeveloperRepository repository)
        {
            this.developerRepository = repository;
        }

        public IEnumerable<Developer> ListarDevelopers()
        {
            return developerRepository.ListarDevelopers();
        }

        public Developer ObterDeveloper(int id)
        {            
            return developerRepository.ObterDeveloper(id);
        }


        public int IncluirDeveloper(Developer developer)
        {            
            return developerRepository.IncluirDeveloper(developer);
        }

        public void AlterarDeveloper(Developer developer, int id)
        {
            if (developer.Id != id)
                throw new ArgumentNullException("Developer não encontrado");

            developerRepository.AlterarDeveloper(developer, id);
        }

        public void DeletarDeveloper(int id)
        {
            developerRepository.DeletarDeveloper(id);
        }

    }
}
