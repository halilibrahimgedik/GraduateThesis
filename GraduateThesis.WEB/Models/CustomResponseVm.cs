namespace GraduateThesis.WEB.Models
{
    public class CustomResponseVm<T>
    {
        public T Data { get; set; }

        public List<string> Errors { get; set; }


        public static CustomResponseVm<T> Success(T data)
        {
            return new CustomResponseVm<T> { Data = data };
        }

        //public static CustomResponseVm<T> Success(int statusCode)
        //{
        //    return new CustomResponseVm<T> { StatusCode = statusCode };
        //}


        public static CustomResponseVm<T> Fail(List<string> Errors)
        {
            return new CustomResponseVm<T> { Errors = Errors };
        }

        public static CustomResponseVm<T> Fail(string Error)
        {
            return new CustomResponseVm<T> { Errors = new List<string> { Error } };
        }
    }
}
