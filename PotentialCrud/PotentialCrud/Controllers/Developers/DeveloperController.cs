using Microsoft.AspNetCore.Mvc;
using PotentialCrud.Business;
using PotentialCrud.Model.Developers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotentialCrud.Controllers.Developers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private IDeveloperBusiness developerBusiness;

        public DeveloperController(IDeveloperBusiness developerBusiness)
        {
            this.developerBusiness = developerBusiness;
        }

        [HttpGet]
        public IEnumerable<Developer> Get()
        {
            return developerBusiness.ListarDevelopers();
        }

        [HttpGet("{id}", Name = "DeveloperCriado")]
        public IActionResult GetById(int id)
        {
            try
            {
                var developer = developerBusiness.ObterDeveloper(id);
                return Ok(developer);
            }
            catch (Exception)
            {
                return NotFound();
                throw;
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Developer developer)
        {
            if (ModelState.IsValid)
            {
                developerBusiness.IncluirDeveloper(developer);
                return new CreatedAtRouteResult("DeveloperCriado", new { id = developer.Id }, developer);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Developer developer, int id)
        {
            try
            {
                if (developer.Id != id)
                    return BadRequest();

                developerBusiness.AlterarDeveloper(developer, id);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                developerBusiness.DeletarDeveloper(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
            
        }
    }
}
