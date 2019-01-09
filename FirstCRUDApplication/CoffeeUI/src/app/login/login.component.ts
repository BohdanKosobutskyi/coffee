import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication-service';
import { IntegrationService } from '../services/integration-service';

  @Component({
    selector: 'login',
    templateUrl: './login.component.html',
    providers: [AuthenticationService, IntegrationService]
  })
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;

  @Input() loginData = { email: '', password: '' };
    
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      materialFormCardPasswordEx: ['', Validators.required],
      materialFormCardEmailEx: ['', Validators.required]
    });

    // reset login status
    this.authenticationService.logout();
  }

  onSubmit() {
    this.loading = true;
    this.authenticationService.login(this.loginData);
    this.loading = false;
    
    this.router.navigate(['/admin/home']);
  }
}
