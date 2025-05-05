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

            return await _context.Formulas
                    .Include(f => f.Product)
                    .Select(f => new FormulaDTO
                    {
                        ProductId = f.ProductId,
                        StepsData = JsonConvert.DeserializeObject<StepsDataDTO>(f.StepsData),
                        FormulaTitle = f.Title,
                        ProductName = f.Product.ProductName
                    })
                    .ToListAsync(cancellationToken);
        }

        public async Task<FormulaDTO> GetFormula(int id, CancellationToken cancellationToken)
        {

            var result = await _context.Formulas
                    .Include(f => f.Product)
                    .FirstOrDefaultAsync(f => f.ProductId == id, cancellationToken);

            if (result == null)
                return new FormulaDTO();

            return new FormulaDTO
            {
                ProductName = result?.Product?.ProductName,
                FormulaTitle = result?.Title,
                ProductId = result.ProductId,
                StepsData = JsonConvert.DeserializeObject<StepsDataDTO>(result?.StepsData)
            };
        }
    }
}
