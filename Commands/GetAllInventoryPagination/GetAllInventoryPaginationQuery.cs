using MediatR;


public class GetAllInventoryPaginationQuery : IRequest<IEnumerable<InventoryDTO>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetAllInventoryPaginationQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
