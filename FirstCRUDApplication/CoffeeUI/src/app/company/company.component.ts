import { Component, Input } from '@angular/core';
import { CompanyService } from './company.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { AppConfig } from './../configuration/config.component';

@Component({
    selector: 'app-company',
    templateUrl: './company.component.html',
    styleUrls: ['./company.component.css'],
    providers: [CompanyService, AppConfig]
})

export class CompanyComponent {
  private cardForm: FormGroup;
  private companyAddUrl: string;
  
    @Input() companyData = { email: '', title: '', password: '', phone: ''};

  constructor(public rest: CompanyService, public fb: FormBuilder, public errorHandler: GlobalErrorHandlerService, private config: AppConfig) {
      this.cardForm = fb.group({
        materialFormCardNameEx: ['', Validators.required],
        materialFormCardEmailEx: ['', [Validators.email, Validators.required]],
        materialFormCardConfirmEx: ['', Validators.required],
        materialFormCardPasswordEx: ['', Validators.required]
    });

      this.config.getConfigs().subscribe(data => {
        this.companyAddUrl = data['companyAdd'];
      });
    }

  addCompany() {
      this.rest.addCompany(this.companyData, this.companyAddUrl).subscribe((result) => { }, (err) => {
        this.errorHandler.handleError(err);
      });
    }
}
