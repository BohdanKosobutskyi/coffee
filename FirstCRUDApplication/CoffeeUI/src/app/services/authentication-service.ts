import { Injectable } from '@angular/core';
import { IntegrationService } from './integration-service';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { Router } from '@angular/router';
import { AppConfig } from './../configuration/config.component';

@Injectable()
export class AuthenticationService {
    webTokenUrl: string;

  constructor(private integrationService: IntegrationService,
    private errorHandler: GlobalErrorHandlerService,
    private router: Router,
    private config: AppConfig) {
        this.config.getConfigs().subscribe(data => {
            this.webTokenUrl = data['webToken'];
        });
  }

  login(companyData: any) {
      
      this.integrationService.sendData(companyData, this.webTokenUrl).subscribe((result) => {
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
