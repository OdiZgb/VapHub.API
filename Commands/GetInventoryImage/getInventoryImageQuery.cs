using MediatR;


  public class getInventoryImageQuery : IRequest<string>
  {
    public string _barcode ;
    public getInventoryImageQuery(string barcode)
    {
      this._barcode = barcode;
    }
  }
