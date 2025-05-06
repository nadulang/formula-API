using formula_API.DTO;

namespace formula_API.Interface
{
    public interface IFormulaRepository
    {
        public Task<List<FormulaDTO>> GetFormulas(CancellationToken cancellationToken);
        public Task<StepsDataDTO> GetSteps(string productCode, CancellationToken cancellationToken);
        public Task<StepParameter> GetParameter(string productCode, string stepTitle, CancellationToken cancellationToken);
    }
}
