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
    this.http.get('/api/values').subscribe(result => {
      this.values = result.json() as string[];
    }, error => console.error(error));
  }

}

