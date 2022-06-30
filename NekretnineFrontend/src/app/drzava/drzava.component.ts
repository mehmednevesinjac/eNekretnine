import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Drzava} from "../Models/drzava";
import {OidcSecurityService} from "angular-auth-oidc-client";
import {BaseSearchObject} from "../Models/BaseSearchObject";
import {Event, Params} from "@angular/router";
import {PageEvent} from "@angular/material/paginator";

@Component({
  selector: 'app-drzava',
  templateUrl: './drzava.component.html',
  styleUrls: ['./drzava.component.css']
})
export class DrzavaComponent implements OnInit {

  constructor(private HttpKlijent: HttpClient, private oidcSecurityServices : OidcSecurityService) {
  }

  ngOnInit(): void {
    this.getDrzave();
  }

  UrediPodatak: Drzava = new Drzava(0, "");
  Podaci: any;
  FilterDrzava: string = '';
  pagination : BaseSearchObject = new BaseSearchObject(null,1,5);
  pageEvent : PageEvent;
  token = this.oidcSecurityServices.getAccessToken();
  httpOptions = {
    headers: new HttpHeaders({Authorization: 'Bearer '+this.token})
  };
  httpParams : Params;

  public getDrzave(event?: PageEvent) {
    if(event == null)
      this.httpParams =  new HttpParams().set('Page',this.pagination.Page.toString() ).set('PageSize', this.pagination.PageSize).set('naziv',this.FilterDrzava)
    else
       this.httpParams =  new HttpParams().set('Page',(event.pageIndex+1).toString() ).set('PageSize', this.pagination.PageSize)
      this.HttpKlijent.get<any>(MojConfig.adresa_servera + "/api/Drzave", {
        headers: this.httpOptions.headers,
        params: this.httpParams,
        observe: 'response' as 'response',
      }).subscribe((rezultat: HttpResponse<any>) => {
        this.Podaci = rezultat.body;
        this.pagination = JSON.parse(rezultat.headers.get('x-pagination'));
      });
  }

  getDrzavaFilter() {
    if (this.Podaci == null) {
      return [];
    }
    return this.Podaci.filter((x: Drzava) => x.naziv.length == 0 || (x.naziv.toLowerCase().startsWith(this.FilterDrzava.toLowerCase())));
  }

  urediDrzava(x: any) {
    this.UrediPodatak = x;
  }

  izbrisiDrzavu(x: any) {
    this.HttpKlijent.delete(MojConfig.adresa_servera + "/api/Drzave/" + x.drzavaId,this.httpOptions).subscribe((rezultat: any) => {
      console.log(rezultat);
      this.getDrzave();
    })
  }

  receiveMessage()
  {
    this.getDrzave();
  }

  NovaDrzava(UrediPodatak: Drzava) {
    UrediPodatak.drzavaId = -1;
    UrediPodatak.naziv = "";
  }
}



