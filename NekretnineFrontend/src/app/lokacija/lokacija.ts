export class Lokacija{
  public lokacijaID : number;
  public gradId : number;
  public drzavaID : number;
  public ulica : string;
  public broj : number;
  constructor(lokacijaID : number,gradId : number, drzavaID : number, ulica : string, broj : number)
  {
    this.gradId = gradId;
    this.drzavaID = drzavaID;
    this.lokacijaID = lokacijaID;
    this.ulica = ulica;
    this.broj = broj;
  }

}

export class LokacijaVM{
  public gradId : number;
  public ulica : string;
  public broj : number;
  public lokacijaId : number;
  constructor(lokacijaId : number,gradId : number, ulica : string, broj : number)
  {
    this.lokacijaId = lokacijaId;
    this.gradId = gradId;
    this.ulica = ulica;
    this.broj = broj;
  }

}
