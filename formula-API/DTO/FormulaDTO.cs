using Newtonsoft.Json.Linq;

namespace formula_API.DTO
{
    public class FormulaDTO
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public JObject StepsData { get; set; }
    }
}