import { Component, signal } from '@angular/core';
import { Header } from './header/header';
import { User } from './user/user';
import { DUMMY_USERS, DummyUser } from './dummy-users';
import { Tasks } from './tasks/tasks';
import { NgForOf } from "../../node_modules/@angular/common/types/_common_module-chunk";

@Component({
  selector: 'app-root',
  imports: [Header, User, Tasks, NgForOf],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  users = DUMMY_USERS;
  selectedUserId: string | null = null;

  get selectedUserName(): string|null {
    return DUMMY_USERS.find((u) => u.id === this.selectedUserId)?.name || null;
  }

  onSelectUser(id: string) {
    this.selectedUserId = id;
  }
}
