export class Grad{
  public gradId : number;
  public  drzavaID : number;
  public naziv : string;
  public izmjenaGrada : boolean;
  constructor(gradId : number, drzavaID : number, naziv : string, izmjenaGrada : boolean)
  {
    this.gradId = gradId;
    this.drzavaID = drzavaID;
    this.naziv = naziv;
    this.izmjenaGrada = izmjenaGrada;
  }

}
