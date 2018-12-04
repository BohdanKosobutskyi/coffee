import { Component, OnInit } from '@angular/core';
import { UserHttpService } from './user-http.service';
import { User } from './user'

@Component({
  selector: 'user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  providers: [UserHttpService]
})
export class UserListComponent {

  users: User[] = [];
  
  constructor(public httpService: UserHttpService) {
    this.httpService.getUsers().subscribe(data => this.users = <User[]>data);
  }

  elements: any = [
    { id: 1, first: 'Mark', last: 'Otto', handle: '@mdo' },
    { id: 2, first: 'Jacob', last: 'Thornton', handle: '@fat' },
    { id: 3, first: 'Larry', last: 'the Bird', handle: '@twitter' },
  ];

  headElements = ['ID', 'Phone', 'Password', 'Register Date'];

}
