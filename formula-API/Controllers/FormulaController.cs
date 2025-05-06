using formula_API.DTO;
using formula_API.Interface;
using formula_API.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetFormulas(CancellationToken cancellationToken = default)
        {
            var result = new BaseResponse<List<FormulaDTO>>();

            try
            {
                var data = await _repository.GetFormulas(cancellationToken);
                result.Data = data;
            }
            catch (Exception e)
            {
                result.ErrorMessage = $"Error get formulas: {e.Message}";
            }
            return Ok(result);
        }

        [HttpGet("get-steps")]
        public async Task<IActionResult> GetSteps(string productCode, CancellationToken cancellationToken = default)
        {
            var result = new BaseResponse<StepsDataDTO>();
            try
            {
                var data = await _repository.GetSteps(productCode, cancellationToken);
                if (data == null) return NotFound();
                result.Data = data;
            }
            catch (Exception e)
            {

                result.ErrorMessage = $"Error get formula: {e.Message}";
            }
            return Ok(result);
        }

        [HttpGet("get-parameter")]
        public async Task<IActionResult> GetParameter(string productCode, string stepTitle, CancellationToken cancellationToken = default)
        {
            var result = new BaseResponse<StepParameter>();
            try
            {
                var data = await _repository.GetParameter(productCode, stepTitle, cancellationToken);
                if (data == null) return NotFound();
                result.Data = data;
            }
            catch (Exception e)
            {
                result.ErrorMessage = $"Error get parameter: {e.Message}";
            }
            return Ok(result);
        }
    }
}
