namespace Secop.Core.Application
{
    public class DataActionResult
    {
        public bool Success { get; set; }
        public string? ExceptionMessage { get; set; }
        public int RowsAffected { get; set; }
    }
}
