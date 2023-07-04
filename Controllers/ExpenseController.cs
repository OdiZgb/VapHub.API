using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("expense")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly IMediator _mediator;
    public ExpenseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("addExpenseCategory")]
    public async Task<ActionResult<ExpenseCategory>> addExpenseCategory([FromBody] ExpenseCategoryDTO expenseCategory)
    {
        var command = new AddExpenseCategoryCommand(expenseCategory);
        var expense = await _mediator.Send(command);
        return Ok(expense);
    }
    [HttpPost("addExpenseItem")]
    public async Task<ActionResult<ExpenseCategory>> addExpenseItem([FromBody] ExpenseItemDTO expenseItemDTO)
    {
        var command = new AddExpenseItemCommand(expenseItemDTO);
        var item = await _mediator.Send(command);
        return Ok(item);
    }
 

    [HttpGet("getAllExpenseCategories")]
    public async Task<ActionResult<IEnumerable<ExpenseCategory>>> getAllExpenseCategories()
    {
        var query = new GetAllExpenseCategoriesQuery();
        var Expenses = await _mediator.Send(query);
        return Ok(Expenses);
    }
}