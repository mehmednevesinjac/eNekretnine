import {Component, Input, OnInit} from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import {LokacijaVM} from "../lokacija";

@Component({
  selector: 'app-uredi-lokacija',
  templateUrl: './uredi-lokacija.component.html',
  styleUrls: ['./uredi-lokacija.component.css']
})
export class UrediLokacijaComponent implements OnInit {
  @Input() urediLokacija : any;
  constructor(private HttpKlijent : HttpClient) { }
  odabranaDrzava : any;
  drzave : any;
  gradovi : any;
  odabraniGrad : any;
  ngOnInit(): void {
    this.getDrzave();
    this.getGrad();
    this.odabraniGrad = this.urediLokacija.gradId;
    this.odabranaDrzava = this.urediLokacija.grad.drzavaId;
    console.log(this.urediLokacija.grad.drzavaId);
    console.log(this.urediLokacija.gradId);
  }

  snimiLokacija() {
    if (this.urediLokacija.lokacijaID == -1)
    {
      this.dodajLokaciju();
    }
    else {
      this.updateLokacija();
    }
  }

  getDrzave() {
    this.HttpKlijent.get(MojConfig.adresa_servera + "/api/Drzave").subscribe(rezultat => {
      this.drzave = rezultat;
    });
  }
  getGrad() {
    this.HttpKlijent.get(MojConfig.adresa_servera + "/api/Grad").subscribe(rezultat => {
      this.gradovi = rezultat;
    });
  }

  dodajLokaciju() {
    var temp  = {ulica : this.urediLokacija.ulica, broj : this.urediLokacija.broj, gradId : this.odabraniGrad};
    if(temp.ulica != null && temp.broj != null && temp.gradId != null) {
      this.HttpKlijent.post(MojConfig.adresa_servera + "/api/Lokacija", temp).subscribe((rezultat: any) => {
        console.log(rezultat);
      })
    }
    this.urediLokacija.ulica = "";
    this.urediLokacija.broj = 0;
    this.urediLokacija.lokacijaID = -1;
    this.urediLokacija.gradId = 0;
    this.urediLokacija.drzavaId = 0;
  }

  private updateLokacija() {
    var temp : LokacijaVM = new LokacijaVM(this.urediLokacija.lokacijaID,this.odabraniGrad, this.urediLokacija.ulica, this.urediLokacija.broj)
    this.HttpKlijent.post(MojConfig.adresa_servera+"/api/Lokacija/" + this.urediLokacija.lokacijaID,temp).subscribe(rezultat => {
      console.log(rezultat);
    })
    this.urediLokacija.ulica = "";
    this.urediLokacija.broj = 0;
    this.urediLokacija.lokacijaID = -1;
    this.urediLokacija.gradId = 0;
    this.urediLokacija.drzavaId = 0;
  }

}
