import { Component, Input } from '@angular/core';
import { Task } from './task/task';
import { dummyTasks } from './dummy-tasks';
import { ITask } from './task/task.model';
import { NewTask } from './new-task/new-task';
import { INewTask } from './new-task/new-task.model';
import { TasksService } from './tasks.service';

@Component({
  selector: 'app-tasks',
  imports: [Task, NewTask],
  templateUrl: './tasks.html',
  styleUrl: './tasks.css',
})
export class Tasks {
  @Input({ required: true })
  userId!: string;

  @Input({ required: true })
  name!: string;

  isAddingTask = false;

  constructor(
    private readonly tasksService: TasksService
  ) {}

  get selectedUserTasks() {
    return this.tasksService.getUserTasks(this.userId);
  }

  onStartAddTask() {
    this.isAddingTask = true;
  }

  onCloseAddTask() {
    this.isAddingTask = false;
  }
}
