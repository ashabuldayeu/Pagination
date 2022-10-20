namespace Pagination
{
    public class PaginationRequest<TKey>
    {
        public uint Take { get; set; }

        public TKey LastKey { get; set; }
    }
}