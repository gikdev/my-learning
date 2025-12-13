import { Component } from "@angular/core"
import { ServerStatus } from "./dashboard/server-status/server-status"
import { Tickets } from "./dashboard/tickets/tickets"
import { Traffic } from "./dashboard/traffic/traffic"
import { Header } from "./header/header"
import { DashboardItemComponent } from "./dashboard/dashboard-item/dashboard-item";

@Component({
	selector: "app-root",
	imports: [Header, ServerStatus, Traffic, Tickets, DashboardItemComponent],
	standalone: true,
	templateUrl: "./app.html",
})
export class App {}
