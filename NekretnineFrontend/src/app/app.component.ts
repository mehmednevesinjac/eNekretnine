import { Component, OnInit } from '@angular/core';
import {
  OidcClientNotification,
  OidcSecurityService,
  OpenIdConfiguration,
  UserDataResult
} from "angular-auth-oidc-client";
import {Observable, ObservedValueOf} from "rxjs";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  configuration$: any;
  userDataChanged$: Observable<OidcClientNotification<any>>;
  userData$: Observable<UserDataResult>;
  isAuthenticated = false;

  constructor(public oidcSecurityService: OidcSecurityService) {
  }
  ngOnInit() {
  this.oidcSecurityService.checkAuth().subscribe(({isAuthenticated}) => console.log('App authenticated',isAuthenticated));
    this.configuration$ = this.oidcSecurityService.getConfiguration();
    this.userData$ = this.oidcSecurityService.userData$;

   /* this.oidcSecurityService.isAuthenticated$.subscribe(({ isAuthenticated }) => {
      this.isAuthenticated = isAuthenticated;

      console.warn('authenticated: ', isAuthenticated);
    });
   */
  }

  title = 'NekretnineFrontend';

  Login() {
    this.oidcSecurityService.authorize();
  }

  Logout() {
    this.oidcSecurityService.logoff();
  }
}
