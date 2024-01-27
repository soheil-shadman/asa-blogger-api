namespace AsaBloggerApi.Src.Models
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string Errors { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}