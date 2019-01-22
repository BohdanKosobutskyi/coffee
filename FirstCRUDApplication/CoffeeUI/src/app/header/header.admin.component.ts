import { Component, Input, ElementRef, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { IntegrationService } from './../services/integration-service';
import { AuthenticationService } from '../services/authentication-service';
import { Router } from '@angular/router';

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
    private authenticationService: AuthenticationService,
    private router: Router) {
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

  goToUsers() {
      this.router.navigate(['/admin/users']);
  }

  goToPosts() {
      this.router.navigate(['/admin/posts']);
  }

  goToHome() {
      this.router.navigate(['/admin/home']);
  }
}
