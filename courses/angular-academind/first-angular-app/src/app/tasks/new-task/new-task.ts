import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { INewTask } from './new-task.model';
import { TasksService } from '../tasks.service';

@Component({
  selector: 'app-new-task',
  imports: [FormsModule],
  templateUrl: './new-task.html',
  styleUrl: './new-task.css',
})
export class NewTask {
  @Input({ required: true })
  userId!: string

  @Output()
  close = new EventEmitter<void>();

  private readonly tasksService = inject(TasksService)

  enteredTitle = '';
  enteredSummary = '';
  enteredDueDate = '';

  onClose() {
    this.close.emit();
  }

  onSubmit() {
    this.tasksService.addTask({
      dueDate: this.enteredDueDate,
      summary: this.enteredSummary,
      title: this.enteredTitle,
    }, this.userId)

    this.onClose();
  }
}
