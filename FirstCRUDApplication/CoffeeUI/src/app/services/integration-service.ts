import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable()
export class IntegrationService {

  constructor(private http: HttpClient) { }

  getAll(apiEndpoint: string) {
    return this.http.get(apiEndpoint)
  }

  public sendData(postBody: any, url: string): Observable<HttpResponse<any>> {
    
    let httpHeaders = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post<any>(url, postBody,
      {
        headers: httpHeaders,
        observe: 'response'
      }
    ).pipe(
      catchError(error => {
        return throwError(error);
      })
    );
  }
}
