import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Drzava} from "./drzava";

@Component({
  selector: 'app-drzava',
  templateUrl: './drzava.component.html',
  styleUrls: ['./drzava.component.css']
})
export class DrzavaComponent implements OnInit {

  constructor(private HttpKlijent: HttpClient) {
  }

  ngOnInit(): void {
    this.getDrzave();
  }
  Podaci: any;
  UrediPodatak: Drzava = new Drzava(0, "");
  FilterDrzava: string = '';

  getDrzave() {
    this.HttpKlijent.get(MojConfig.adresa_servera + "/api/Drzave").subscribe(rezultat => {
      this.Podaci = rezultat;
    });
  }

  getDrzavaFilter() {
    if (this.Podaci == null) {
      return [];
    }
    return this.Podaci.filter((x: any) => x.naziv.length == 0 || (x.naziv.toLowerCase().startsWith(this.FilterDrzava.toLowerCase())));
  }

  urediDrzava(x: any) {
    this.UrediPodatak = x;
  }

  izbrisiDrzavu(x: any) {
    this.HttpKlijent.delete(MojConfig.adresa_servera + "/api/Drzave/" + x.drzavaID).subscribe((rezultat: any) => {
      console.log(rezultat);
      this.getDrzave();
    })
  }


  NovaDrzava(UrediPodatak: Drzava) {
    this.UrediPodatak.drzavaID = -1;
    this.UrediPodatak.naziv = "";
  }
}



