import {Component, Input, OnInit} from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-uredi-grad',
  templateUrl: './uredi-grad.component.html',
  styleUrls: ['./uredi-grad.component.css']
})
export class UrediGradComponent implements OnInit {
  @Input() urediGrad : any;
  constructor(private HttpKlijent : HttpClient) { }
  odabranaDrzava : any;
  drzave : any;
  ngOnInit(): void {
    this.getDrzave()

  }

  snimiGrad() {
    if (this.urediGrad.gradId == 0)
    {
      this.dodajGrad();
    }
    else {
      this.updateGrad();
    }
    this.promijeniBoolean();
    console.log(this.urediGrad.izmjenaGrada);
  }

  getDrzave() {
    this.HttpKlijent.get(MojConfig.adresa_servera + "/api/Drzave").subscribe(rezultat => {
      this.drzave = rezultat;
    });
  }

  dodajGrad() {
    var temp  = {naziv : this.urediGrad.naziv, drzavaId : this.odabranaDrzava};
    if(temp.naziv != null) {
      this.HttpKlijent.post(MojConfig.adresa_servera + "/api/Grad", temp).subscribe((rezultat: any) => {
        console.log(rezultat);
      })
    }
    this.promijeniBoolean();
  }

  private updateGrad() {
    this.urediGrad.drzavaId =  this.odabranaDrzava
    this.HttpKlijent.post(MojConfig.adresa_servera+"/api/Grad/" + this.urediGrad.gradId,this.urediGrad).subscribe(rezultat => {
      console.log(rezultat);
    })
    this.promijeniBoolean();
  }

  promijeniBoolean() {
    this.urediGrad.izmjenaGrada = false;
    console.log(this.urediGrad.izmjenaGrada + " promijeni bool");
  }
}
