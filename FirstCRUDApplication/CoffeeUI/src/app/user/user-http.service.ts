import { throwError, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';


@Injectable()
export class UserHttpService {

  constructor(private http: HttpClient) { }

  getUsers(apiEndpoint: string) {
    return this.http.get(apiEndpoint)
  }
}
