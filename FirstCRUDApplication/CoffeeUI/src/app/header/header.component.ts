import { Component, Input, ElementRef, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { IntegrationService } from './../services/integration-service';
import { AuthenticationService } from '../services/authentication-service';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers: [IntegrationService, AuthenticationService]
})

export class HeaderComponent {
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
