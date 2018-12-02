import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { HomeComponent } from './home.component';
import { CompanyComponent } from './company/company.component';

// MDB Angular Free
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { MDBBootstrapModule , CheckboxModule, WavesModule, ButtonsModule, InputsModule, IconsModule, ChartsModule } from 'angular-bootstrap-md'

// определение маршрутов
const appRoutes: Routes = [
  { path: 'hometest', component: HomeComponent }
];


@NgModule({
    declarations: [AppComponent, HomeComponent, CompanyComponent],
  imports: [BrowserModule,
    HttpModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    CheckboxModule,
    IconsModule,
    MDBBootstrapModule.forRoot(),
    ButtonsModule,
    ChartsModule,
    InputsModule.forRoot(),
    WavesModule.forRoot()],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
