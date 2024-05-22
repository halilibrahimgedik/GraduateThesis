using System.Text.Json.Serialization;

namespace GraduateThesis.WEB.Models
{
    public class CustomResponseVm<T>
    {
        public T Data { get; set; }

        public bool IsSuccessfull { get; set; } = true;
        public List<string> Errors { get; set; }


        public static CustomResponseVm<T> Success(T data)
        {
            return new CustomResponseVm<T> { Data = data, IsSuccessfull = true };
        }

        public static CustomResponseVm<T> Success()
        {
            return new CustomResponseVm<T> { IsSuccessfull = true };
        }


        public static CustomResponseVm<T> Fail(List<string> Errors)
        {
            return new CustomResponseVm<T> { Errors = Errors, IsSuccessfull = false };
        }

        public static CustomResponseVm<T> Fail(string Error)
        {
            return new CustomResponseVm<T> { Errors = new List<string> { Error }, IsSuccessfull = false };
        }
    }
}
