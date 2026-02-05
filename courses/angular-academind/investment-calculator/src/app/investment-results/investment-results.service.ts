import { Injectable, signal } from '@angular/core';
import { CalculateInvestmentResultsInput } from './calculate-investment-results-input.model';
import { AnnualData } from './annual-data.model';

@Injectable({ providedIn: 'root' })
export class InvestmentResultsService {
  annualData = signal<AnnualData[]>([]);

  calculate(input: CalculateInvestmentResultsInput): void {
    const { annualInvestment, duration, expectedReturn, initialInvestment } = input;
    let investmentValue = initialInvestment;

    for (let i = 0; i < duration; i++) {
      const year = i + 1;

      const interestEarnedInYear = investmentValue * (expectedReturn / 100);
      investmentValue += interestEarnedInYear + annualInvestment;

      const totalInterest = investmentValue - annualInvestment * year - initialInvestment;

      const newAnnualData: AnnualData = {
        year,
        interest: interestEarnedInYear,
        valueEndOfYear: investmentValue,
        annualInvestment,
        totalInterest,
        totalAmountInvested: initialInvestment + annualInvestment * year,
      };

      this.annualData.update((currentData) => [...currentData, newAnnualData]);
    }
  }
}
