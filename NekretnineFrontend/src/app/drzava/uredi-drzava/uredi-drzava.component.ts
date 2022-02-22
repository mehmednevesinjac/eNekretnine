import {Component, Input, OnInit} from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-uredi-drzava',
  templateUrl: './uredi-drzava.component.html',
  styleUrls: ['./uredi-drzava.component.css']
})
export class UrediDrzavaComponent implements OnInit {
  @Input() urediDrzavu : any;
  constructor(private HttpKlijent : HttpClient) { }

  ngOnInit(): void {
  }

  snimiDrzava() {
    if (this.urediDrzavu.drzavaID == -1)
    {
      this.DodajDrzavu();
    }
    else {
      this.updateDrzavu();
    }
  }

  DodajDrzavu() {
    var temp  = {naziv : this.urediDrzavu.naziv};
    if(temp.naziv != null) {
      this.HttpKlijent.post(MojConfig.adresa_servera + "/api/Drzave", temp).subscribe((rezultat: any) => {
        console.log(rezultat);
      })
    }
    this.urediDrzavu.naziv = "";
    this.urediDrzavu.drzavaID = 0;
  }

  private updateDrzavu() {
    console.log(this.urediDrzavu.drzavaID);
    this.HttpKlijent.post(MojConfig.adresa_servera+"/api/Drzave/" + this.urediDrzavu.drzavaID,this.urediDrzavu).subscribe(rezultat => {
      console.log(rezultat);
    })
    this.urediDrzavu.naziv = "";
    this.urediDrzavu.drzavaID = 0;
  }
}
