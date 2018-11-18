import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home.component';

// определение маршрутов
const appRoutes: Routes = [
  { path: 'hometest', component: HomeComponent }
];


@NgModule({
  declarations: [AppComponent, HomeComponent],
  imports: [BrowserModule, HttpModule, RouterModule.forRoot(appRoutes)],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
