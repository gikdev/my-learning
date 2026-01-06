import { Component, computed, inject } from '@angular/core';
import { InvestmentResultsService } from './investment-results.service';

@Component({
  selector: 'app-investment-results',
  imports: [],
  templateUrl: './investment-results.html',
  styleUrl: './investment-results.css',
})
export class InvestmentResults {
  private readonly investmentResultsService = inject(InvestmentResultsService);

  public annualData = computed(() => this.investmentResultsService.annualData())
  public showResults = computed(() => this.annualData().length > 0)
}
