import { Component, OnInit } from '@angular/core';
import { UserListView } from '../../user/user';
import { GlobalErrorHandlerService } from '../../global-error-handler.service';
import { AppConfig } from '../../configuration/config.component';
import { IntegrationService } from '../../services/integration-service';

@Component({
    selector: 'user-list-admin',
    templateUrl: './user-list.admin.component.html',
    providers: [AppConfig, IntegrationService]
})
export class UserListAdminComponent {

    users: UserListView[] = [];
    userGetAdminUrl: string;
    userDeleteFomCompanyUrl: string;

    constructor(public integrationService: IntegrationService, public errorHandler: GlobalErrorHandlerService, public config: AppConfig) {

        this.config.getConfigs().subscribe(data => {
            this.userGetAdminUrl = data['userListAdmin'];
            this.userDeleteFomCompanyUrl = data['userDeleteFromCompany'];

            this.integrationService.getAll(this.userGetAdminUrl).subscribe((data) => { this.users = <UserListView[]>data }, (err) => {
                this.errorHandler.handleError(err);
            });
        });
    }

    headElements = ['ID', 'Phone', 'Password', 'Register Date', 'Is Confirm', 'Actions'];

    deleteUser(user_id: number) {
        const postBody = {
            user_id: user_id
        };

        this.integrationService.sendData(postBody, this.userDeleteFomCompanyUrl).subscribe((result) => {
            this.integrationService.getAll(this.userGetAdminUrl).subscribe((data) => { this.users = <UserListView[]>data }, (err) => {
                this.errorHandler.handleError(err);
            });
        },
            (err) => {
                this.errorHandler.handleError(err);
            });
    }

}
