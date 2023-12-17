namespace SampleProject.API
{
    public class Page<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItemCount { get; set; }
        public int PageSize { get; set; }
        public int Offset { get { return PageSize * (PageNo - 1); } }
        public int PageNo { get; set; }
    }

    public class DataResponse<T> where T : class
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class ListResponse<T> where T : class
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Items { get; set; }
    }

    public class PageResponse<T> : ListResponse<T> where T : class
    {
        public int TotalItemCount { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }

    public static class APIModelFactory
    {
        public static ListResponse<T> MakeListResponse<T>(int code, string message, IEnumerable<T> items) where T : class
        {
            return new ListResponse<T>()
            {
                Code = code,
                Message = message,
                Items = items
            };
        }

        public static PageResponse<T> MakePageResponse<T>(int code, string message, Page<T> page) where T : class
        {
            return new PageResponse<T>()
            {
                Code = code,
                Message = message,

                PageNo = page.PageNo,
                PageSize = page.PageSize,
                TotalItemCount = page.TotalItemCount,
                Items = page.Items
            };
        }

        public static DataResponse<T> MakeDataResponse<T>(int code, string message, T data) where T : class
        {
            return new DataResponse<T>()
            {
                Code = code,
                Message = message,
                Data = data

            };
        }
    }
}