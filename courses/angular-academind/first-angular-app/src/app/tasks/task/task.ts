import { Component, Input } from '@angular/core';
import { UserTask } from '../../user-task';

@Component({
  selector: 'app-task',
  imports: [],
  templateUrl: './task.html',
  styleUrl: './task.css',
})
export class Task {
  @Input({ required: true })
  task!: UserTask;
}
