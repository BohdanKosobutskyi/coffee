import { Component, Input } from '@angular/core';
import { CompanyService } from './company.service';

@Component({
    selector: 'app-company',
    templateUrl: './company.component.html',
    styleUrls: ['./company.component.css'],
    providers: [CompanyService]
})

export class CompanyComponent {

    @Input() companyData = { email: '', title: '' };

    constructor(public rest: CompanyService) { }

    addCompany() {
        this.rest.addCompany(this.companyData).subscribe((result) => { }, (err) => {
            console.log(err);
        });
    }
}
