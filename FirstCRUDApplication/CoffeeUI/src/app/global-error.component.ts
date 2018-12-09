import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  template: `
        <h2>{{statusText}}</h2>
        <h2>Error message : {{message}}</h2>`
})
export class GlobalErrorComponent {
  statusText: string;
  message: string;

  constructor(private route: ActivatedRoute) {
    this. route.queryParams.subscribe(
      (queryParam: any) => {
        this.statusText = queryParam['statusText'];
        this.message = queryParam['error'];
      }
    );
  }
} 
