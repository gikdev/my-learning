import { Component, signal } from '@angular/core';
import { Header } from "./header/header";
import { UserInput } from "./user-input/user-input";
import { InvestmentResults } from "./investment-results/investment-results";

@Component({
  selector: 'app-root',
  imports: [Header, UserInput, InvestmentResults],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {}
