using PotentialCrud.Model.Developers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotentialCrud.Business
{
    public interface IDeveloperBusiness
    {
        IEnumerable<Developer> ListarDevelopers();

        Developer ObterDeveloper(int id);

        int IncluirDeveloper(Developer developer);

        void AlterarDeveloper(Developer developer, int id);

        void DeletarDeveloper(int id);
    }
}
