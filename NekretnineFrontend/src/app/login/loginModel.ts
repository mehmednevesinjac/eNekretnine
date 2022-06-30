export class LoginModel{
  public  Username : string;
  public Password : string;
  public ReturnUrl : string;

  constructor(username : string, password : string, returnUrl : string)
  {
    this.Username = username;
    this.Password = password;
    this.ReturnUrl = returnUrl;
  }

}
