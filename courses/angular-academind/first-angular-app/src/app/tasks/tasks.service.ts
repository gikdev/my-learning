import { Injectable } from "@angular/core";
import { dummyTasks } from "./dummy-tasks";
import { INewTask } from "./new-task/new-task.model";
import { ITask } from "./task/task.model";

@Injectable({ providedIn: "root" })
export class TasksService {
  private readonly localStorageKey = 'tasks';
  private tasks: ITask[] = dummyTasks;

  constructor() {
    const tasks = localStorage.getItem(this.localStorageKey)

    if (tasks) {
      this.tasks = JSON.parse(tasks);
    }
  }

  getUserTasks = (userId: string) =>
    this.tasks.filter((t) => t.userId === userId);

  addTask(newTask: INewTask, userId: string) {
    this.tasks.push({
      ...newTask,
      id: new Date().getTime().toString(),
      userId,
    });

    this.saveTasks();
  }

  removeTask(id: string) {
    this.tasks = this.tasks.filter(t => t.id !== id)

    this.saveTasks();
  }

  private saveTasks() {
    localStorage.setItem(this.localStorageKey, JSON.stringify(this.tasks));
  }
}
