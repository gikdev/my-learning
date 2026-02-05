# TaskForge – Business Specification

## Overview

TaskForge allows organizing, prioritizing, and tracking tasks. Users can group tasks into projects, assign optional labels, and mark tasks as pending or completed.

---

## Core Concepts

### Project

* Represents a collection of tasks with a shared goal.
* Each project has a **unique name**.
* Projects can be active or completed.
* Completed projects do not accept new tasks

---

### Task

* Represents a single piece of work.
* Each task has a **title** (required) and **description** (optional).
* Tasks belong to a project.
* Tasks have a **status**: pending or completed.
* Tasks can optionally have a **priority**: low, medium, high.
* Tasks can optionally have **labels**.

---

### Label

* Represents a category or tag.
* Labels have a **unique name**.
* Tasks can have multiple labels.
* Labels do not belong to a specific project.

---

## Rules & Constraints

1. **Unique Names**

   * Label names must be unique.
   * Project names must be unique.
   * Task titles must be unique within a project.
   * Normalized and trimmed ones are the same → then are not unique.

2. **Status Rules**

   * Tasks can only have two statuses: pending or completed.
   * Completed tasks can be marked pending again if needed.

3. **Projects**

   * Completed projects cannot accept new tasks.

4. **Labels**

   * Tasks can have multiple labels.
   * Removing a label removes it from all tasks using it.

---

### Example Scenarios

1. **Adding a Task**

   * A new task with a title and optional description is added to an active project.
   * If a task with the same title exists in the project, the action is rejected.

2. **Completing a Task**

   * A task’s status is changed from pending to completed.
   * The task remains in the project and retains its labels and priority.

3. **Managing Labels**

   * A label can be created with a unique name.
   * Tasks can be assigned or unassigned from labels.
