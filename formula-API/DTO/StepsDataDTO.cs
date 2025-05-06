namespace formula_API.DTO
{
    public class StepsDataDTO
    {
        public List<Step> Steps { get; set; }
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
        public float suhu { get; set; }
        public float tekanan { get; set; }
    }

    public class Substep
    {
        public string subStepTitle { get; set; }
        public List<Substep> sub_steps { get; set; }
    }
}
