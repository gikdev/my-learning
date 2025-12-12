import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import { ITask } from './task.model';
import { Card } from '../../shared/card/card';
import { TasksService } from '../tasks.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-task',
  imports: [Card, DatePipe],
  templateUrl: './task.html',
  styleUrl: './task.css',
})
export class Task {
  @Input({ required: true })
  task!: ITask;

  private readonly tasksService = inject(TasksService);

  onCompleteTask() {
    this.tasksService.removeTask(this.task.id);
  }
}
