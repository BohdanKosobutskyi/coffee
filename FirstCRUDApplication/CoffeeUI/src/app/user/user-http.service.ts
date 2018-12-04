import { throwError, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';


@Injectable()
export class UserHttpService {

  public apiEndpoint = 'http://localhost:58114/api/users/all';

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get(this.apiEndpoint)
  }
}
