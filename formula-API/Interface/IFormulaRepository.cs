using formula_API.DTO;

namespace formula_API.Interface
{
    public interface IFormulaRepository
    {
        public Task<List<FormulaDTO>> GetFormulas(CancellationToken cancellationToken);
        public Task<FormulaDTO> GetFormula(int id, CancellationToken cancellationToken);
    }
}
