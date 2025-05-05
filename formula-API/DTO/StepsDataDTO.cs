namespace formula_API.DTO
{
    public class StepsDataDTO
    {
        public List<Step> steps { get; set; }
    }

    public class Step
    {
        public string stepTitle { get; set; }  // untuk step
        public StepParameter parameters { get; set; }
        public List<Substep> sub_steps { get; set; }
    }

    public class StepParameter
    {
        public string deskripsi { get; set; }
        public int durasi { get; set; }
        public double suhu { get; set; }
        public double tekanan { get; set; }
    }

    public class Substep
    {
        public string subStepTitle { get; set; }
        public List<Substep> sub_steps { get; set; }
    }
}
