namespace GraduateThesis.WEB.Models
{
    public class CustomResponseVm<T>
    {
        public T Data { get; set; }

        public List<string> Errors { get; set; }
    }
}
