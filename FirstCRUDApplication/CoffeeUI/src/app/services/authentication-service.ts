import { Injectable } from '@angular/core';
import { IntegrationService } from './integration-service';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService {
  constructor(private integrationService: IntegrationService,
    private errorHandler: GlobalErrorHandlerService,
    private router: Router) { }

  login(companyData: any) {

    this.integrationService.sendData(companyData, "http://localhost:58114/api/web/token").subscribe((result) => {
      if (result) {
        localStorage.setItem('currentUser', JSON.stringify(result.body));
        this.router.navigate(['/admin/home']);
        }
    }, (err) => {
      this.errorHandler.handleError(err);
    });
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.router.navigate(['/home']);
  }

  isLogin(): boolean {
    if (localStorage.getItem('currentUser') !== null) {
      return true;
    }
    else {
      return false;
    }
  }
}
