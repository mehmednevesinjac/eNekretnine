import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from "@angular/common/http";
import {OidcSecurityService} from "angular-auth-oidc-client";
import {GradComponent} from "../../grad/grad.component";

@Component({
  selector: 'app-uredi-grad',
  templateUrl: './uredi-grad.component.html',
  styleUrls: ['./uredi-grad.component.css']
})
export class UrediGradComponent implements OnInit {
  @Input() urediGrad : any;
  @Output() messageEvent = new EventEmitter();
  constructor(private HttpKlijent : HttpClient,private oidcSecurityServices : OidcSecurityService, private comp : GradComponent) { }
  token = this.oidcSecurityServices.getAccessToken();
  httpOptions = {
    headers: new HttpHeaders({Authorization: 'Bearer '+this.token})
  };
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
  }

  getDrzave() {

    this.HttpKlijent.get<any>(MojConfig.adresa_servera + "/api/Drzave", {
      headers: this.httpOptions.headers,
    //  params: this.httpParams,
      observe: 'response' as 'response',
    }).subscribe((rezultat: HttpResponse<any>) => {
      this.drzave = rezultat.body;
    });
  }

  dodajGrad() {
    var temp  = {naziv : this.urediGrad.naziv, drzavaId : this.odabranaDrzava};
    if(temp.naziv != null) {
      this.HttpKlijent.post(MojConfig.adresa_servera + "/api/Gradovi", temp,this.httpOptions).subscribe((rezultat: any) => {
        console.log(rezultat);
      })
    }
    this.promijeniBoolean();
  }

  private updateGrad() {
    this.urediGrad.drzavaId =  this.odabranaDrzava
    this.HttpKlijent.put(MojConfig.adresa_servera+"/api/Gradovi/" + this.urediGrad.gradId,this.urediGrad,this.httpOptions).subscribe(rezultat => {
      console.log(rezultat);
    })
    this.promijeniBoolean();
  }

  promijeniBoolean() {
    this.urediGrad.izmjenaGrada = false;
    console.log(this.urediGrad.izmjenaGrada + " promijeni bool");
  }
}
