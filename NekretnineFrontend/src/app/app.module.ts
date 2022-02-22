import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatDividerModule} from "@angular/material/divider";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {CommonModule} from "@angular/common";
import {FlexLayoutModule} from "@angular/flex-layout";
import {ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import {MatInputModule} from "@angular/material/input";
import { DrzavaComponent } from './drzava/drzava.component';
import { HttpClientModule} from "@angular/common/http";
import { FormsModule} from "@angular/forms";
import { UrediDrzavaComponent } from './drzava/uredi-drzava/uredi-drzava.component';
import { GradComponent } from './grad/grad.component';
import { LokacijaComponent } from './lokacija/lokacija.component';
import { UrediGradComponent } from './grad/uredi-grad/uredi-grad.component';
import {MatOptionModule} from "@angular/material/core";
import {MatSelectModule} from "@angular/material/select";
import { UrediLokacijaComponent } from './lokacija/uredi-lokacija/uredi-lokacija.component';

@NgModule({
  declarations: [
    AppComponent,
    DrzavaComponent,
    UrediDrzavaComponent,
    GradComponent,
    LokacijaComponent,
    UrediGradComponent,
    UrediLokacijaComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatDividerModule,
    CommonModule,
    FlexLayoutModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatSidenavModule,
    MatToolbarModule,
    RouterModule.forRoot([
      {path: 'drzava', component: DrzavaComponent},
      {path: 'grad', component: GradComponent},
      {path: 'lokacija', component: LokacijaComponent},

    ]),
    HttpClientModule,
    FormsModule,
    MatOptionModule,
    MatSelectModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
