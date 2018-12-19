import { Component, OnInit } from '@angular/core';
import { UserListView } from './user';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { AppConfig } from './../configuration/config.component';
import { IntegrationService } from './../services/integration-service';

@Component({
  selector: 'user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  providers: [AppConfig, IntegrationService]
})
export class UserListComponent {

    users: UserListView[] = [];
    userGetAllUrl: string;
    userDeleteUrl: string;

  constructor(public integrationService: IntegrationService, public errorHandler: GlobalErrorHandlerService, public config: AppConfig) {

    this.config.getConfigs().subscribe(data => {
        this.userGetAllUrl = data['userList'];
        this.userDeleteUrl = data['userDelete'];
        
        this.integrationService.getAll(this.userGetAllUrl).subscribe((data) => { this.users = <UserListView[]>data }, (err) => {
            this.errorHandler.handleError(err);
        });
    });
  }

  headElements = ['ID', 'Phone', 'Password', 'Register Date', 'Is Confirm', 'Actions'];

  deleteUser(user_id: number) {
      const postBody = {
          user_id: user_id
      };

      this.integrationService.sendData(postBody, this.userDeleteUrl).subscribe((result) => {
          this.integrationService.getAll(this.userGetAllUrl).subscribe((data) => { this.users = <UserListView[]>data }, (err) => {
              this.errorHandler.handleError(err);
          });
      },
          (err) => {
              this.errorHandler.handleError(err);
          });
  }

}
