namespace formula_API.DTO
{
    public class FormulaDTO
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string FormulaTitle { get; set; }
        public StepsDataDTO StepsData { get; set; }
    }
}