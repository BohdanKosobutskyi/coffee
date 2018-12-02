import { Component, Input } from '@angular/core';
import { CompanyService } from './company.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'app-company',
    templateUrl: './company.component.html',
    styleUrls: ['./company.component.css'],
    providers: [CompanyService]
})

export class CompanyComponent {
    cardForm: FormGroup;
  
    @Input() companyData = { email: '', title: '' };

  constructor(public rest: CompanyService, public fb: FormBuilder) {
      this.cardForm = fb.group({
        materialFormCardNameEx: ['', Validators.required],
        materialFormCardEmailEx: ['', [Validators.email, Validators.required]],
        materialFormCardConfirmEx: ['', Validators.required],
        materialFormCardPasswordEx: ['', Validators.required]
      });
    }

    addCompany() {
        this.rest.addCompany(this.companyData).subscribe((result) => { }, (err) => {
            console.log(err);
        });
    }
}
