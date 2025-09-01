namespace MyWebApi.Core.DTO
{
        public class PaginationDTO<T>
        {
            public int Index { get; set; }
            public int TotalCount { get; set; }
            public int PageSize { get; set; }
            public int PageCount { get; set; }
            public int CurrentPage { get; set; }
            public List<T> Data { get; set; }
        }

        public class PaginationRequest
        {
            public int Index { get; set; }
            public int PageSize { get; set; }
        }
}
