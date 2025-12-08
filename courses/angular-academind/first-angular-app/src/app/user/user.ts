import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DummyUser } from '../dummy-users';

@Component({
  selector: 'app-user',
  imports: [],
  templateUrl: './user.html',
  styleUrl: './user.css',
})
export class User {
  @Input({ required: true })
  user!: DummyUser;

  @Output()
  select = new EventEmitter<string>();

  get imagePath() {
    return `/users/${this.user.avatar}`;
  }

  // avatar = input.required<string>();
  // name = input.required<string>();
  // select = output<string>()
  // imagePath = computed(() => `/users/${this.avatar}`);

  onSelectUser() {
    this.select.emit(this.user.id);
  }
}
