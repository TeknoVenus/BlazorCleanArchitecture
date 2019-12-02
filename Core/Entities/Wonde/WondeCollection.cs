using System.Collections.Generic;

namespace Core.Entities
{
    public class WondeCollection<T>
    {
        public IEnumerable<T> Data { get; set; }
        public WondeMetadata Meta { get; set; }
    }

    public class WondeMetadata
    {
        public PaginationInfo Pagination { get; set; }
    }

    public class PaginationInfo
    {
        public string Next { get; set; }
        public string Previous { get; set; }
        public bool More { get; set; }
        public string PerPage { get; set; }
        public string CurrentPage { get; set; }
    }
}