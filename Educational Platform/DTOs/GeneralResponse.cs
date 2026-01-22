namespace Educational_Platform.DTOs
{
    public class GeneralResponse<T>
    {
        public bool IsSucceeded { get; set; }
        public string Messsage { get; set; }
        public T Data { get; set; }
    }
}
