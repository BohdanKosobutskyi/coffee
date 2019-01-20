import { Component, Input, ElementRef, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { IntegrationService } from './../services/integration-service';
import { AuthenticationService } from '../services/authentication-service';

@Component({
  selector: 'header-admin',
  templateUrl: './header.admin.component.html',
  styleUrls: ['./header.admin.component.css'],
  providers: [IntegrationService, AuthenticationService]
})

export class HeaderAdminComponent {
  private cardFormLogin: FormGroup;
  private loginForm: FormGroup;

  loginFormModalEmail = new FormControl('', Validators.email);
  loginFormModalPassword = new FormControl('', Validators.required);

  @Input() loginData = { email: '', password: '' };

  constructor(public integrationService: IntegrationService,
    public fb: FormBuilder,
    public errorHandler: GlobalErrorHandlerService,
    private elem: ElementRef,
    private authenticationService: AuthenticationService) {
    this.cardFormLogin = fb.group({
      materialFormCardPasswordLoginEx: ['', Validators.required],
      materialFormCardEmailLoginEx: ['', Validators.required]
    });
  }

  login() {
    this.authenticationService.login(this.loginData);
  }

  logout() {
    this.authenticationService.logout();
  }

  isLogin(): boolean {
    return this.authenticationService.isLogin();
  }
}
