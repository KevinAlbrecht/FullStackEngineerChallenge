import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { PerformanceReview } from '@pay/shared/models';
import { PerformanceReviewItem } from './performance-review-item.model';

@Component({
  selector: 'pay-performances-list',
  templateUrl: './performances-list.component.html',
  styleUrls: ['./performances-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PerformancesListComponent {
  private selectedPerformance: PerformanceReviewItem;
  private _performances: PerformanceReview[];

  @Output() selectPerformance = new EventEmitter<PerformanceReview>();
  @Input() set performances(value: PerformanceReview[]) {
    this._performances = value;
    this.deselect();
    this.performanceItems = this.projectToListItem(value);
  }
  get performances(): PerformanceReview[] {
    return this._performances;
  }

  get hasPerformanceAssigned(): boolean {
    return this.performances && this.performances.length > 0 ? true : false;
  }

  performanceItems: PerformanceReviewItem[];

  constructor() {}

  deselect(): void {
    if (this.selectedPerformance) {
      this.selectedPerformance.isSelected = false;
      this.selectedPerformance = null;
    }
    this.selectPerformance.emit(null);
  }
  select(performance: PerformanceReviewItem): void {
    if (this.selectedPerformance) {
      this.selectedPerformance.isSelected = false;
    }
    performance.isSelected = true;
    this.selectedPerformance = performance;

    const originalPerformance: PerformanceReview = {
      concerned: performance.concerned,
      date: performance.date,
      description: performance.description,
      id: performance.id,
      title: performance.title,
      assigned: performance.assigned,
    };
    this.selectPerformance.emit(originalPerformance);
  }

  private projectToListItem(ps: PerformanceReview[]): PerformanceReviewItem[] {
    if (!ps) {
      return [] as PerformanceReviewItem[];
    }
    return ps.map(
      (p) => ({ ...p, isSelected: false } as PerformanceReviewItem)
    );
  }
}
