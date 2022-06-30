import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {OidcSecurityService} from "angular-auth-oidc-client";
import {DrzavaComponent} from "../drzava.component"
import {Drzava} from "../../Models/drzava";

@Component({
  selector: 'app-uredi-drzava',
  templateUrl: './uredi-drzava.component.html',
  styleUrls: ['./uredi-drzava.component.css']
})
export class UrediDrzavaComponent implements OnInit {
  @Input() urediDrzavu : any;
  @Output() messageEvent = new EventEmitter();
  constructor(private HttpKlijent : HttpClient,private oidcSecurityServices : OidcSecurityService, private comp : DrzavaComponent) { }
  token = this.oidcSecurityServices.getAccessToken();
  httpOptions = {
    headers: new HttpHeaders({Authorization: 'Bearer '+this.token})
  };
  ngOnInit(): void {
  }

  snimiDrzava() {
    if (this.urediDrzavu.drzavaId == -1)
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
      this.HttpKlijent.post(MojConfig.adresa_servera + "/api/Drzave", temp,this.httpOptions).subscribe((rezultat: any) => {
        console.log(rezultat);
      })
    }
    this.urediDrzavu.naziv = "";
    this.urediDrzavu.drzavaId = 0;
    this.messageEvent.emit();
  }

  private updateDrzavu() {
    this.HttpKlijent.put(MojConfig.adresa_servera+"/api/Drzave/" + this.urediDrzavu.drzavaId,this.urediDrzavu,this.httpOptions).subscribe(rezultat => {
      console.log(rezultat);
    })
    this.urediDrzavu.naziv = "";
    this.urediDrzavu.drzavaId = 0;
    this.messageEvent.emit();
  }
}
