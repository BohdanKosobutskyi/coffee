import { Component, OnInit } from '@angular/core';
import { UserHttpService } from './user-http.service';
import { User } from './user';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { AppConfig } from './../configuration/config.component';

@Component({
  selector: 'user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  providers: [UserHttpService, AppConfig]
})
export class UserListComponent {

  users: User[] = [];
  userList: string;

  constructor(public httpService: UserHttpService, public errorHandler: GlobalErrorHandlerService, public config: AppConfig) {

    this.config.getConfigs().subscribe(data => {
      this.userList = data['userList'];

      this.httpService.getUsers(this.userList).subscribe((data) => { this.users = <User[]>data }, (err) => {
        this.errorHandler.handleError(err);
      });
    });
  }

  headElements = ['ID', 'Phone', 'Password', 'Register Date'];

}
