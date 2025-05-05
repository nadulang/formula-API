using formula_API.DTO;
using formula_API.Interface;
using formula_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace formula_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulaController : ControllerBase
    {
        private readonly IFormulaRepository _repository;

        public FormulaController(IFormulaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetFormulas (CancellationToken cancellationToken = default)
        {
            var result = new BaseResponse<List<FormulaDTO>>();

            try
            {
                var data = await _repository.GetFormulas(cancellationToken);
                result.Data = data;
            }
            catch (Exception e)
            {

                result.ErrorMessage = $"Error get formulas: {e}";
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {

            var result = new BaseResponse<List<FormulaDTO>>();
            var data = await _repository.GetFormula(cancellationToken);
            result.Data = data;
            return Ok(result);
        }

        [HttpPost("add")]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("update")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("delete")]
        public void Delete(int id)
        {
        }
    }
}
