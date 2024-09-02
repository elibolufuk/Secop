namespace Secop.Core.Application.Results
{
    public class DataActionResult
    {
        public bool Success { get; set; }
        public string? ExceptionMessage { get; set; }
        public int RowsAffected { get; set; }
    }
}
