
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllExpenseCategoriesQueryHandeler : IRequestHandler<GetAllExpenseCategoriesQuery, IEnumerable<ExpenseCategoryDTO>>
{
    private readonly IMapper _mapper;
    public AppDbContext _dbContext { set; get; }
    private readonly IMediator _mediator;
    public GetAllExpenseCategoriesQueryHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ExpenseCategoryDTO>> Handle(GetAllExpenseCategoriesQuery request, CancellationToken cancellationToken)
    {
        List<ExpenseCategory> expenseCategories = await _dbContext.ExpenseCategories
            .Include(e => e.expenseItems)
            .ToListAsync();
            var expenseCategoriesDTO =_mapper.Map<List<ExpenseCategoryDTO>>(expenseCategories);
        return (IEnumerable<ExpenseCategoryDTO>)expenseCategoriesDTO;
    }
}