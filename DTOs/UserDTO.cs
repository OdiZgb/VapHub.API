public class UserDTO{
  public int? Id{set;get;}
  public string? Name{set;get;}
  public string? Email{set;get;}
  public string? Password{set;get;}
  public int? SecurityLevel{set;get;}
  public int? UserType {set;get;}
  public bool IsTrader{set;get;}
  public bool IsEmployee{set;get;}
  public bool IsClient{set;get;}
  public string? token{set;get;}
}