import { Component, OnInit } from '@angular/core';
import {
  Feedback,
  PerformanceReview,
  WrittenFeedback,
} from '@pay/shared/models';
import { AuthService, PerformanceService } from '@pay/shared/services';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';

@Component({
  selector: 'pay-performances-page',
  templateUrl: './performances-page.component.html',
  styleUrls: ['./performances-page.component.scss'],
})
export class PerformancesPageComponent implements OnInit {
  readonly $performanceReviews: Observable<PerformanceReview[]>;

  selectedPerformance: PerformanceReview = null;

  constructor(
    private performanceService: PerformanceService,
    private authService: AuthService
  ) {
    this.$performanceReviews = this.performanceService.$assignedPerformanceToFeedback;
  }

  onSubmitFeedback(wfb: WrittenFeedback): void {
    this.authService.$currentUser.pipe(first()).subscribe((user) => {
      const feedback: Feedback = {
        cooperationRating: wfb.cooperation,
        qualityRating: wfb.quality,
        initiativeRating: wfb.initiative,
        comment: wfb.comment,
        creatorEmployeeId: user.employeeId,
        performanceId: this.selectedPerformance.id,
      };
      this.performanceService.writeFeedback(feedback).subscribe((_) => {
        this.performanceService.getAssigned();
        this.selectedPerformance = null;
      });
    });
  }

  onPerformanceSelected(performance: PerformanceReview): void {
    this.selectedPerformance = performance;
  }
  ngOnInit(): void {
    this.performanceService.getAssigned();
  }
}
