import { Component, Input } from '@angular/core';
import { Task } from './task/task';
import { UserTask } from '../user-task';
import { dummyTasks } from './dummy-tasks';

@Component({
  selector: 'app-tasks',
  imports: [Task],
  templateUrl: './tasks.html',
  styleUrl: './tasks.css',
})
export class Tasks {
  @Input({ required: true })
  userId!: string;

  @Input({ required: true })
  name!: string;

  tasks: UserTask[] = dummyTasks;

  get selectedUserTasks() {
    return this.tasks.filter((t) => t.userId === this.userId);
  }
}
