import { Component } from "@angular/core"
import { NewTicket } from "./new-ticket/new-ticket"

@Component({
	selector: "app-tickets",
	standalone: true,
	templateUrl: "./tickets.html",
	styleUrl: "./tickets.css",
	imports: [NewTicket],
})
export class Tickets {}
