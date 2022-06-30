import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {OidcSecurityService} from "angular-auth-oidc-client";
import {MojConfig} from "../moj-config";
import {LoginModel} from "./loginModel";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private HttpKlijent: HttpClient, private oidcSecurityServices : OidcSecurityService) {
  }
  token = this.oidcSecurityServices.getAccessToken();
  loginModel : LoginModel = new LoginModel("test","Pass123."," http://localhost:4200/")
  httpOptions = {
    headers: new HttpHeaders({Authorization: 'Bearer '+this.token})
  };


  ngOnInit(): void {
  }

  Login() {
    /* this.HttpKlijent.post(MojConfig.adresa_auth + "/Auth/Login",this.loginModel,this.httpOptions).subscribe(rezultat => {
      console.log(this.oidcSecurityServices.checkAuth());
    });
     */

    this.oidcSecurityServices.authorize()
  }

}
