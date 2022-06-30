import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Grad} from "./grad"
import {BaseSearchObject} from "../Models/BaseSearchObject";
import {PageEvent} from "@angular/material/paginator";
import {Params} from "@angular/router";
import {OidcSecurityService} from "angular-auth-oidc-client";
@Component({
  selector: 'app-grad',
  templateUrl: './grad.component.html',
  styleUrls: ['./grad.component.css'],
})
export class GradComponent implements OnInit {

  constructor(private HttpKlijent: HttpClient, private oidcSecurityServices : OidcSecurityService) {
  }

  ngOnInit(): void {
    this.getGrad();
  }
  Podaci: any;
  UrediPodatak: Grad = new Grad(0,0 ,"", false);
  FilterGrad: string = '';
  pagination : BaseSearchObject = new BaseSearchObject(null,1,5);
  pageEvent : PageEvent;
  token = this.oidcSecurityServices.getAccessToken();
  httpOptions = {
    headers: new HttpHeaders({Authorization: 'Bearer '+this.token})
  };
  httpParams : Params;

  public getGrad(event?: PageEvent) {
    if(event == null)
      this.httpParams =  new HttpParams().set('Page',this.pagination.Page.toString() ).set('PageSize', this.pagination.PageSize).set('naziv',this.FilterGrad)
    else
      this.httpParams =  new HttpParams().set('Page',(event.pageIndex+1).toString() ).set('PageSize', this.pagination.PageSize)
    this.HttpKlijent.get<any>(MojConfig.adresa_servera + "/api/Gradovi", {
      headers: this.httpOptions.headers,
      params: this.httpParams,
      observe: 'response' as 'response',
    }).subscribe((rezultat: HttpResponse<any>) => {
      this.Podaci = rezultat.body;
      this.pagination = JSON.parse(rezultat.headers.get('x-pagination'));
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
  }

  izbrisiGrad(x: any) {
    this.HttpKlijent.delete(MojConfig.adresa_servera + "/api/Gradovi/" + x.gradId,this.httpOptions).subscribe((rezultat: any) => {
      console.log(rezultat);
      this.getGrad();
    })
  }


  NoviGrad(UrediPodatak: Grad) {
    UrediPodatak.izmjenaGrada = true;
    UrediPodatak.gradId = 0;
    UrediPodatak.drzavaID = 0;
    UrediPodatak.naziv = "";
  }

}
