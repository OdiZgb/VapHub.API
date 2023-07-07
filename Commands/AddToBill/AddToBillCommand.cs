using MediatR;


  public class AddToBillCommand : IRequest<BillDTO>
  {
    public BillDTO _billDTO;
    public AddToBillCommand(BillDTO billDTO)
    {
      _billDTO = billDTO;
    }
  }
