import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { InvestmentResultsService } from '../investment-results/investment-results.service';

@Component({
  selector: 'app-user-input',
  imports: [FormsModule],
  templateUrl: './user-input.html',
  styleUrl: './user-input.css',
})
export class UserInput {
  private readonly investmentResultsService = inject(InvestmentResultsService);

  enteredInitialInvestment = signal('');
  enteredAnnualInvestment = signal('');
  enteredExpectedReturn = signal('');
  enteredDuration = signal('');

  handleSubmit() {
    this.investmentResultsService.calculate({
      annualInvestment: +this.enteredAnnualInvestment(),

      duration: +this.enteredDuration(),

      expectedReturn: +this.enteredExpectedReturn(),

      initialInvestment: +this.enteredInitialInvestment(),
    });
  }
}
