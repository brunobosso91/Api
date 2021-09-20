using Moq;
using PotentialCrud.Business;
using PotentialCrud.Model.Developers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TesteUnitario.Developers
{
    public class DeveloperTeste //: IDeveloperBusiness
    {
        [Fact]
        public void TesteDeveloper()
        {
            var mock = new Mock<IDeveloperBusiness>();
            mock.Setup(p => p.ListarDevelopers());

            var listaDeveloper = mock.Object.ListarDevelopers();
            IEnumerable<Developer> c = null;

            Assert.NotEqual<Developer>(c, listaDeveloper);
        }

        [Fact]
        public void TesteObterDeveloper()
        {
            var mock = new Mock<IDeveloperBusiness>();

            mock.Setup(p => p.ObterDeveloper(It.IsAny<int>()));

            mock.Object.ObterDeveloper(1);
            mock.Object.ObterDeveloper(2);
            mock.Object.ObterDeveloper(3);

            mock.Verify(e => e.ObterDeveloper(It.IsAny<int>()), Times.AtLeast(3));
        }

        [Fact]
        public void TesteIncluirDeveloper()
        {
            var mock = new Mock<IDeveloperBusiness>();           

            mock.Setup(p => p.IncluirDeveloper(It.IsAny<Developer>()));

            mock.Object.IncluirDeveloper(
                new Developer {  Nome = "Developer", 
                                 DataNascimento = DateTime.Parse("01/01/1990"),
                                 Hobby = "Programação",
                                 Idade = 31,
                                 Sexo = "M"}
                );

            

            mock.Object.IncluirDeveloper(
                new Developer
                {
                    Nome = "Developer2",
                    DataNascimento = DateTime.Parse("01/01/2000"),
                    Hobby = "Programação",
                    Idade = 21,
                    Sexo = "F"
                }
                );

            mock.Verify(e => e.IncluirDeveloper(It.IsAny<Developer>()), Times.AtLeast(1));
        }

        [Fact]
        public void TesteAlterarDeveloper()
        {
            var mock = new Mock<IDeveloperBusiness>();

            var idInclusao = 1;
            mock.Object.IncluirDeveloper(
                new Developer
                {
                    Id = 1,
                    Nome = "Developer",
                    DataNascimento = DateTime.Parse("01/01/1990"),
                    Hobby = "Programação",
                    Idade = 31,
                    Sexo = "M"
                }
                );            

            mock.Object.AlterarDeveloper(
                new Developer
                {
                    Id = idInclusao,
                    Nome = "Developer2",
                    DataNascimento = DateTime.Parse("01/01/2000"),
                    Hobby = "Programação",
                    Idade = 21,
                    Sexo = "F"
                },
                idInclusao
                );

            mock. Verify(e => e.AlterarDeveloper(It.IsAny<Developer>(), It.IsAny<int>()), Times.AtLeast(1));
        }

        [Fact]
        public void TesteExcluirDeveloper()
        {
            var mock = new Mock<IDeveloperBusiness>();

            mock.Object.DeletarDeveloper(1);

            mock.Verify(e => e.DeletarDeveloper(It.IsAny<int>()), Times.AtLeast(1));
        }
    }
}
