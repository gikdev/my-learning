# Angular (Academind)

- Component:

```ts
import { Component } from "@angular/core"

@Component({
    selector: "app-header",
    templateUrl: './header.html',
    styleUrl: './header.css',
    standalone: true,
    imports: [],
})
export class Header {}
```

- For using a component: gotta import it in the `imports`.

- Create a component using the CLI.

```sh
ng g c my-button
# OR
ng generate component my-button
```

- Interpolation:

```html
<img src="{{ user.avatar }}" />
<img [src]="user.avatar" />
<div>{{ user.name }}</div>
```

- Event handling:

```html
<button (click)="onSelectUser()">Click me!</button>
```

- For states: we can have props...

- For states: we can have Signals!

```ts
@Component({
    template: `<p>{{ name() }}. {{ greeting() }}</p>`,
})
export class MyButton {
    name = signal("")

    greeting = computed(() => `Hello, ${name()}!`)

    updateName() {
        this.name.set("new name")
        // or
        this.name.update(currentName => currentName.trim())
    }
}
```

- Inputs:

```ts
export class SomeComponent {
    @Input()
    firstName?: string

    @Input({ required: true })
    jobTitle!: string

    firstName = input<string>() // or input<string>("")
    jobTitle = input.required<string>()
}
```

- Outputs:

```ts
export class SomeComponent {
    @Output()
    select = new EventEmitter<string>()

    select = output<string>()

    tellThem() {
        this.select.emit("Hi!")
    }
}
```

```html
<!-- Parent -->
<app-some-component (select)="doSomething($event)" />
<!-- $event holds the submitted data by the event emitter! -->
```

- Looping:

```html
<!-- track is important! -->
@for (user of users; track user.id) {
    <li>
        <p>{{ user.name }}</p>
        <p>{{ user.age }}</p>
    </li>
}
```

- If:

```html
@if (isValid) {
    <p>You're good to go!</p>
} @else {
    <p>Fix the errors!</p>
}
```

- Conditional className:

```html
<button [class.active]="selected"></button>
<!-- then: -->
<button class="active"></button>
```

- Form directive binding:

```ts
import { FormsModule } from "@angular/forms"

@Component({
    imports: [FormsModule],
    template: `
        <input name="product-name" [(ngModel)]="enteredProductName" />
    `,
})
export class Sth {
    enteredProductName: ""
    // or
    enteredProductName = signal("")
}
```

- Form submission handling:

```html
<form (ngSubmit)="handleSubmit()">
    <!-- Will auto e.preventDefault() because of `FormsModule` -->
    <!-- ... -->
</form>
```
```ts
handleSubmit() {
    // do whatev...
}
```

- Content projection:

```html
<div>
    <ng-content />
    <!-- {children} basically... 😂 -->
</div>
```

- Pipes:

```ts
import { DatePipe } from "@angular/common"
{
    imports: [DatePipe],
}
```
```html
<time>{{ task.dueDate | date:'fullDate' }}</time>
<!-- '2025-12-31' -> 'Wednesday, December 31, 2025' -->
```

- Service:

```ts
@Injectable({ providedIn: "root" })
export class TasksService {}
```

```ts
constructor(
    private readonly tasksService: TasksService
) {}
// or:
private readonly tasksService = inject(TasksService)
```

- Extending built-in components:

```ts
@Components({
    selector: 'button[appBtn], a[appBtn]', // CSS selector
})
```
```html
<!-- somewhere else... -->
<button appBtn>Click me!</button>
```

- Content projection:

```html
<span>
    <ng-content />
</span>

<ng-content select=".icon" />

<!-- filter: -->
<ng-content select="input, textarea" />
```

```html
<button appBtn>
    <!-- goes to the main ng-content -->
    lkajsdflkjasdlfjkasdljfk

    <!-- goes to the select=".icon" -->
    <span class=".icon">
        =&gt;
    </span>

    <!-- OR -->
    <!--
        <ng-content select="icon">
            FALLBACK STUFF...
        </ng-content>
    -->
    <span ngProjectAs="icon">
        ...
    </span>
</button>
```

- View encapsulation:

> Angular doesn't care about content which may EVENTUALLY end up in your component! only what it sees!

- Sees the placeholder...

```ts
@Component({
    // ...
    encapsulation: ViewEncapsulation.None, // disable style scoping
})
```

- Styling the host element:

```css
:host {}
/* Targets the host <app-header> or <button appBtn> for example... */
/* With ViewEncapsulation.None -> doesn't target the <app-header>... sth else... */
```

```ts
@Component({
    host: {
        class: "control", // props added to the host element
        '(click)': 'handleClick()',
    }
})
export class Control {
    // Old
    // @HostBinding("class")
    // hostClassName = "control";

    // Not the recommended one:
    // @HostListener('click') handleClick() {
    //     console.log("Clicked!")
    // }

    private readonly el = inject(ElementRef) // from @angular/core

    handleClick() {
        console.log("Clicked!")
        console.log(this.el) // logs the host element
    }
}
```

- Class binding:

```html
<div
    [class]="{
        status: true,
        'status-online': currentStatus === 'online',
    }"
    [style]="{
        'font-size': 64px
    }"
></div>

<!-- [style.fontSize]="'64px'" -->
```

- Component lifecycle:

```ts
export class Sth implements OnInit
// , OnDestroy
 {

    private destroyRef = inject(DestroyRef)

    // forces `ngOnInit`
    constructor() {}

    // better use `ngOnInit` and not constructor!
    // `ngOnInit` has inputs! but ctor not!

    ngOnInit() {
        // set up
        // setInterval...

        this.destroyRef.onDestroy(() => {
            // clear stuff...
        })
    }

    // ngOnDestroy() {
    //     // cleanup
    //     // clearInterval
    // }
}
```

- Form template variables

```html
<form (ngSubmit)="onSubmit(titleInput)">
    <input #titleInput />

<!-- also: -->
<form (ngSubmit)="onSubmit(titleInput.value)">

<button appBtn #btn></button>
<!-- btn: ButtonComponent (and not, HTMLButtonElement), it's the component instance -->
```

```ts
onSubmit(titleElement: HTMLInputElement) {
    console.dir(titleElement)
    const enteredTitle = titleElement.value
}
```

- Reset form using template variable:

```html
<form (ngSubmit)="onSubmit(..., form)" #form>

<!-- then: form.reset(); -->
```

```ts
// @ViewChild(ButtonComponent) form
@ViewChild('form') form?: ElementRef<HTMLFormElement> // #form tempalte!

// ...
this.form?.nativeElement.reset();
```

```html
<form (ngSubmit)="onSubmit(...)" #form>
```

- Multiple children:

```ts
@ViewChildren(ButtonComponent) btnComps
private form = viewChild<ElementRef<HTMLFormElement>>("form")
// private form = viewChild.required<ElementRef<HTMLFormElement>>("form")
// ...
this.form()?.nativeElement.reset();
```

> viewChild -> in the view,
> contentChild -> whatev like <ng-content select="textarea, input" />

```ts
// children of ng-content would need to `#input` template
@ContentChild('input') private control?: ElementRef<HTMLInputElement | HTMLTextAreaElement>
private control = contentChild<ElementRef<HTMLInputElement | HTMLTextAreaElement>>('input')
```

> Search `angular component lifecycles`...

```ts
name = signal('')

constructor() {
    effect(() => {
        console.log(`my name is now: ${name()}`) // subscribes ✅
    })
}
```

- Loop

```html
@for (ticket of tickets; track ticket.id) {
    <!-- $first : if it's first -->
    <!-- $even : if it's even -->
    <!-- $odd : if it's odd -->
    <!-- $last : if it's last -->
    <!-- $count : if it's count -->
    <p>...</p> - {{ $first }}
} @empty {
    <p>Nothing here!</p>
}
```

- Input & output config:

```ts
// config:
// input('', config)
// input.required<stirng>(config)
ticket = input.required<Ticket>({
    alias: 'data',
    transform: (value) => ``, // only for input, not for output!
})
```

- 2 way databinding:

    1. Using input + output OR:
    2. liek this:

    ```ts
        myAge = model.required<number>() // which is the signal...
    ```
    ```html
    <!-- age can be a singal or a property -->
    <div [(myAge)]="age"></div>
    ```

- Directives are **enhancements** for elements (built-in / component)

- Directives don't have template, unlike components...
    - or: components are directives with a template.
    - for example: `ngModel` is a built-in directive.
    - and `*ngIf` is a built-in/structural directive.

