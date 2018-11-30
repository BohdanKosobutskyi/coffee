import { Company } from './company'
import { throwError, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';


@Injectable()
export class CompanyService {

    public apiEndpoint = 'http://localhost:58114/company/register';

    constructor(private http: HttpClient) { }

    public addCompany(company: Company): Observable<HttpResponse<Company>> {
        const postBody = {
            email: company.email,
            title: company.title
        };

        let httpHeaders = new HttpHeaders({
            'Content-Type': 'application/json'
        });

        return this.http.post<Company>(this.apiEndpoint, postBody,
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
