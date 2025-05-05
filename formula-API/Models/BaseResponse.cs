namespace formula_API.Models
{
    public class BaseResponse<T>
    {
        public int ErrorCode { get; set; } = 0;
        public string ErrorMessage { get; set; } = "Success";
        public T Data { get; set; }
    }
}
