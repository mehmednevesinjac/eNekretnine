import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Lokacija} from "./lokacija"
@Component({
  selector: 'app-lokacija',
  templateUrl: './lokacija.component.html',
  styleUrls: ['./lokacija.component.css'],
})
export class LokacijaComponent implements OnInit {

  constructor(private HttpKlijent: HttpClient) {
  }

  ngOnInit(): void {
    this.getLokacija();
  }
  Podaci: any;
  UrediPodatak: Lokacija = new Lokacija(0,0 ,0,"temp",0);
  FilterLokacija: string = '';

  getLokacija() {
    this.HttpKlijent.get(MojConfig.adresa_servera + "/api/Lokacija").subscribe(rezultat => {
      this.Podaci = rezultat;
    });
  }

  getLokacijaFilter() {
    if (this.Podaci == null) {
      return [];
    }
    return this.Podaci.filter((x: any) => x.ulica.length == 0 || (x.ulica.toLowerCase().startsWith(this.FilterLokacija.toLowerCase())));
  }

  urediLokaciju(x: any) {
    this.UrediPodatak = x;
    this.UrediPodatak.drzavaID = x.grad.drzavaId;
  }

  izbrisiLokaciju(x: any) {
    this.HttpKlijent.delete(MojConfig.adresa_servera + "/api/Lokacija/" + x.lokacijaID).subscribe((rezultat: any) => {
      console.log(rezultat);
      this.getLokacija();
    })
  }


  novaLokacija(UrediPodatak: Lokacija) {
    this.UrediPodatak.gradId = -1;
    this.UrediPodatak.drzavaID = -1;
    this.UrediPodatak.lokacijaID = -1;
    this.UrediPodatak.broj = 0;
    this.UrediPodatak.ulica = "test";
  }

}
