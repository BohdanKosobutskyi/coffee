import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'home-app',
  templateUrl: './home.component.html'
})

export class HomeComponent {
  title = 'app';
  public values: string[];

  constructor(private http: Http) {
   
  }

}

