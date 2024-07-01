

namespace E_Handel.Dtos
{
    public class ResponseDto<T>
    {
        public T? Result { get; set; }
        public bool IsCorrect { get; set; }
        public string? Message { get; set; }
    }
}
