import { Component, OnInit } from '@angular/core';
import { IntegrationService } from './../services/integration-service';
import { CompanyListView } from './company-list-view';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { AppConfig } from './../configuration/config.component';
import { Router } from "@angular/router"

@Component({
  selector: 'company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css'],
  providers: [IntegrationService, AppConfig]
})
export class CompanyListComponent {

  companies: CompanyListView[] = [];
  companyGetAllUrl: string;
  companyApproveUrl: string;

  constructor(public router: Router, public integrationService: IntegrationService, public errorHandler: GlobalErrorHandlerService, public config: AppConfig) {

    this.config.getConfigs().subscribe(data => {
      this.companyGetAllUrl = data['companyList'];
      this.companyApproveUrl = data['approveCompany'];

      this.integrationService.getAll(this.companyGetAllUrl).subscribe((data) => { this.companies = <CompanyListView[]>data }, (err) => {
        this.errorHandler.handleError(err);
      });
    });
  }

  approveCompany(company_id: number, is_approved: boolean) {
    if (is_approved === true) return;

    const postBody = {
      company_id: company_id,
      is_approved: is_approved
    };

    this.integrationService.sendData(postBody, this.companyApproveUrl).subscribe((result) => { }, (err) => {
      this.errorHandler.handleError(err);

      window.location.reload();
    });
  }

  headElements = ['ID', 'Email', 'Title', 'Is Approved', 'Action'];

}