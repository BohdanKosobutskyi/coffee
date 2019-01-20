import { Component, Input, ElementRef, OnInit  } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { AppConfig } from './../configuration/config.component';
import { IntegrationService } from './../services/integration-service';
import { AuthenticationService } from '../services/authentication-service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-company',
    templateUrl: './company.component.html',
    styleUrls: ['./company.component.css'],
  providers: [AppConfig, IntegrationService, AuthenticationService]
})

export class CompanyComponent {
  private cardForm: FormGroup;
  private cardFormLogin: FormGroup;
  private loginForm: FormGroup;
  private companyAddUrl: string;
  private resultRegister: string;

  loginFormModalEmail = new FormControl('', Validators.email);
  loginFormModalPassword = new FormControl('', Validators.required);
  
  @Input() companyData = { email: '', title: '', password: '', phone: '' };
  @Input() loginData = { email: '', password: '' }; 

  constructor(public integrationService: IntegrationService,
    public fb: FormBuilder,
    public errorHandler: GlobalErrorHandlerService,
    private config: AppConfig,
    private elem: ElementRef,
    private authenticationService: AuthenticationService,
    private router: Router) {

    if (this.authenticationService.isLogin()) {
      this.router.navigate(['/admin/home']);
    }
      this.cardForm = fb.group({
        materialFormCardNameEx: ['', Validators.required],
        materialFormCardEmailEx: ['', [Validators.email, Validators.required]],
        materialFormCardConfirmEx: ['', Validators.required],
        materialFormCardPasswordEx: ['', Validators.required],
        materialFormCardPhoneEx: ['', Validators.required]
    });

    this.cardFormLogin = fb.group({
      materialFormCardPasswordLoginEx: ['', Validators.required],
      materialFormCardEmailLoginEx: ['', Validators.required]
    });

      this.config.getConfigs().subscribe(data => {
        this.companyAddUrl = data['companyAdd'];
      });
    }
  

  addCompany() {
    this.integrationService.sendData(this.companyData, this.companyAddUrl).subscribe((result) => {
      this.resultRegister = "Your company was succesffuly registered, please wait for approving";
    }, (err) => {
        this.errorHandler.handleError(err);
      });
  }

  login() {
    this.authenticationService.login(this.loginData);
  }
}
