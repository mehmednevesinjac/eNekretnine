import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Grad} from "./grad"
@Component({
  selector: 'app-grad',
  templateUrl: './grad.component.html',
  styleUrls: ['./grad.component.css'],
})
export class GradComponent implements OnInit {

  constructor(private HttpKlijent: HttpClient) {
  }

  ngOnInit(): void {
    this.getGrad();
  }
  Podaci: any;
  UrediPodatak: Grad = new Grad(0,0 ,"");
  FilterGrad: string = '';
  public dodajGradBoolean = false;
  getGrad() {
    this.HttpKlijent.get(MojConfig.adresa_servera + "/api/Grad").subscribe(rezultat => {
      this.Podaci = rezultat;
    });
  }

  getGradFilter() {
    if (this.Podaci == null) {
      return [];
    }
    return this.Podaci.filter((x: any) => x.naziv.length == 0 || (x.naziv.toLowerCase().startsWith(this.FilterGrad.toLowerCase())));
  }

  urediGrad(x: any) {
    this.UrediPodatak.gradId = x.gradId;
    this.UrediPodatak.drzavaID = x.drzavaId;
    this.UrediPodatak.naziv = x.naziv;
    this.dodajGradBoolean = true;
    console.log(this.dodajGradBoolean + "uredi grad");
  }

  izbrisiGrad(x: any) {
    this.HttpKlijent.delete(MojConfig.adresa_servera + "/api/Grad/" + x.gradId).subscribe((rezultat: any) => {
      console.log(rezultat);
      this.getGrad();
    })
  }


  NoviGrad(UrediPodatak: Grad) {
    console.log(this.dodajGradBoolean + "dodaj grad");
    this.dodajGradBoolean = true;
    this.UrediPodatak.gradId = 0;
    this.UrediPodatak.drzavaID = 0;
    this.UrediPodatak.naziv = "";
    console.log(this.dodajGradBoolean + "dodaj grad");
  }

}
