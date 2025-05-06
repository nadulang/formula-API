using formula_API.Data;
using formula_API.DTO;
using formula_API.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace formula_API.Repository
{
    public class FormulaRepository : IFormulaRepository
    {
        private readonly AppDbContext _context;

        public FormulaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FormulaDTO>> GetFormulas(CancellationToken cancellationToken)
        {
            var result = new List<FormulaDTO>();
            try
            {
                result =  await _context.Formulas
                    .Include(f => f.Product)
                    .Select(f => new FormulaDTO
                    {
                        ProductCode = f.Product.ProductCode,
                        ProductName = f.Product.ProductName,
                        StepsData = JsonConvert.DeserializeObject<StepsDataDTO>(f.StepsData),
                        FormulaTitle = f.Title,
                    })
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                Console.Write(ex);
            }
            return result;
        }

        public async Task<StepsDataDTO> GetSteps(string productCode, CancellationToken cancellationToken)
        {
            var result = new StepsDataDTO();
            try
            {
                var getFormula = await _context.Formulas
                    .Include(f => f.Product)
                    .FirstOrDefaultAsync(x => x.Product.ProductCode == productCode, cancellationToken);

                if (getFormula == null)
                    return null;

                 result = JsonConvert.DeserializeObject<StepsDataDTO>(getFormula?.StepsData);
            }
            catch (Exception ex) 
            {
                var message = ex.Message;
                Console.Write(ex);
            }
            return result;
        }

        public async Task<StepParameter> GetParameter(string productCode, string stepTitle, CancellationToken cancellationToken)
        {
            var result = new StepParameter();
            try
            {
                var getFormula = await _context.Formulas
                         .Include(f => f.Product)
                         .FirstOrDefaultAsync(x => x.Product.ProductCode == productCode, cancellationToken);

                if (getFormula?.StepsData == null)
                    return null;

                var stepsData = JsonConvert.DeserializeObject<StepsDataDTO>(getFormula.StepsData);

                var step = stepsData.Steps.FirstOrDefault(s => s.stepTitle.Contains(stepTitle, StringComparison.OrdinalIgnoreCase));
                result = step?.parameters;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                Console.Write(ex);
            }
            return result;
        }
    }
}
