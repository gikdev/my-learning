import { Component, input, ViewEncapsulation } from "@angular/core"

@Component({
	selector: "app-control",
	standalone: true,
	imports: [],
	templateUrl: "./control.html",
	styleUrl: "./control.css",
  encapsulation: ViewEncapsulation.None,
})
export class Control {
	label = input.required<string>()
}
