using Algebra_Seminar_Drdic.Data;
using Algebra_Seminar_Drdic.Models;
using Algebra_Seminar_Drdic.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductController : ControllerBase
    {
        public readonly ProductRepo _repo;

        public ApiProductController(ProductRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                return Ok(_repo.GetAllProducts());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Product> GetProduct(int id)
        {
            try
            {
                var result = _repo.GetProductById(id);

                if(result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, " Rezultat nije pronađen!");
                }
                      
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Rezultat nije moguće prikazati!");
            }
        }
     }
}
