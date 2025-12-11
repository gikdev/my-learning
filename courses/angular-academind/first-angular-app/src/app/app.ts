import { Component } from '@angular/core';
import { Header } from './header/header';
import { User } from './user/user';
import { DUMMY_USERS, DummyUser } from './dummy-users';
import { Tasks } from './tasks/tasks';

@Component({
  selector: 'app-root',
  imports: [Header, User, Tasks],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  users = DUMMY_USERS;
  selectedUserId: string | null = null;

  get selectedUser(): DummyUser | null {
    return DUMMY_USERS.find((u) => u.id === this.selectedUserId) || null;
  }

  onSelectUser(id: string) {
    this.selectedUserId = id;
  }
}
