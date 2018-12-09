import { Component, Input, ElementRef, ViewChild  } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { AppConfig } from './../configuration/config.component';
import { IntegrationService } from './../services/integration-service';


@Component({
    selector: 'app-company',
    templateUrl: './company.component.html',
    styleUrls: ['./company.component.css'],
    providers: [AppConfig, IntegrationService]
})

export class CompanyComponent {
  private cardForm: FormGroup;
  private companyAddUrl: string;
  private resultRegister: string;
  
    @Input() companyData = { email: '', title: '', password: '', phone: ''};

  constructor(public integrationService: IntegrationService,
    public fb: FormBuilder,
    public errorHandler: GlobalErrorHandlerService,
    private config: AppConfig,
    private elem: ElementRef) {
      this.cardForm = fb.group({
        materialFormCardNameEx: ['', Validators.required],
        materialFormCardEmailEx: ['', [Validators.email, Validators.required]],
        materialFormCardConfirmEx: ['', Validators.required],
        materialFormCardPasswordEx: ['', Validators.required],
        materialFormCardPhoneEx: ['', Validators.required]
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
}
