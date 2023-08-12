using MediatR;


  public class GetAllInventoryQueryByBarcodeQuery : IRequest<IEnumerable<InventoryDTO>>
  {
    public string _barcode ;
    public GetAllInventoryQueryByBarcodeQuery(string barcode)
    {
      this._barcode = barcode;
    }
  }
