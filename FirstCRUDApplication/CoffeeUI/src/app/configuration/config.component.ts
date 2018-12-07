import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AppConfig {

  constructor(public http: HttpClient) { }

  getConfigs() {
    return this.http.get('assets/appsettingsUI.json');
  }
}
