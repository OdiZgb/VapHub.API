using MediatR;


  public class addRefundToBillCommand : IRequest<BillDTO>
  {
    public BillDTO _billDTO;
    public addRefundToBillCommand(BillDTO billDTO)
    {
      _billDTO = billDTO;
    }
  }
