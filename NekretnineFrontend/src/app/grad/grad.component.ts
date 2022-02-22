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
  UrediPodatak: Grad = new Grad(0,0 ,"", false);
  FilterGrad: string = '';
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
    this.UrediPodatak.izmjenaGrada = true;
    console.log(this.UrediPodatak.izmjenaGrada + "uredi grad");
  }

  izbrisiGrad(x: any) {
    this.HttpKlijent.delete(MojConfig.adresa_servera + "/api/Grad/" + x.gradId).subscribe((rezultat: any) => {
      console.log(rezultat);
      this.getGrad();
    })
  }


  NoviGrad(UrediPodatak: Grad) {
    console.log(UrediPodatak.izmjenaGrada + "dodaj grad");
    UrediPodatak.izmjenaGrada = true;
    UrediPodatak.gradId = 0;
    UrediPodatak.drzavaID = 0;
    UrediPodatak.naziv = "";
    console.log(UrediPodatak.izmjenaGrada + "dodaj grad");
  }

}
