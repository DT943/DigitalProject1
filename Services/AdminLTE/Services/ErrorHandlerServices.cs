namespace AdminLTE.Services
{

    public class ApiErrorResponse
    {
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public int StatusCode { get; set; }
        public ErrorDetails Error { get; set; }
    }

    public class ErrorDetails
    {
        public string Message { get; set; }
        public Dictionary<string, List<string>> Data { get; set; }
    }

}
