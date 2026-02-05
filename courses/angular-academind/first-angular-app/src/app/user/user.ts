import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IUser } from './user.model';
import { Card } from "../shared/card/card";

@Component({
  selector: 'app-user',
  imports: [Card],
  templateUrl: './user.html',
  styleUrl: './user.css',
})
export class User {
  @Input({ required: true })
  user!: IUser;

  @Input({ required: true })
  selected!: boolean

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
