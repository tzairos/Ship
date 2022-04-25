public class ResponseBase
{
 
    public Exception Exception { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public object Result { get; set; }
}