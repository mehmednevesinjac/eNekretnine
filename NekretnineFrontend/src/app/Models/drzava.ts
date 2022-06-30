import {BaseSearchObject} from "./BaseSearchObject";

export class Drzava{
  public  drzavaId : number;
  public naziv : string;

  constructor(drzavaID : number, naziv : string)
  {
    this.drzavaId = drzavaID;
    this.naziv = naziv;
  }
}
