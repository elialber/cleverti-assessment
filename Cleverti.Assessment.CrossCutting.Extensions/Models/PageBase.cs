namespace Cleverti.Assessment.CrossCutting.Extensions.Models
{
    public class PageBase
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int TotalPerPage { get; set; }
        public long TotalItems { get; set; }
    }
}
