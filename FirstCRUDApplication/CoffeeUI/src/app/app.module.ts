import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';


import { HomeComponent } from './home.component';
import { CompanyComponent } from './company/company.component'

// определение маршрутов
const appRoutes: Routes = [
  { path: 'hometest', component: HomeComponent }
];


@NgModule({
    declarations: [AppComponent, HomeComponent, CompanyComponent],
    imports: [BrowserModule, HttpModule, RouterModule.forRoot(appRoutes), FormsModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
