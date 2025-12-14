import { Component } from "@angular/core"
import { Button } from "../shared/button/button"

@Component({
	selector: "app-header",
	standalone: true,
	templateUrl: "./header.html",
	styleUrl: "./header.css",
	imports: [Button],
})
export class Header {}
