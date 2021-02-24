import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Feedback, PerformanceReview, WrittenPerformance } from '../models';
import { PerformanceApiService } from './api';

@Injectable({ providedIn: 'root' })
export class PerformanceService {
  constructor(private apiService: PerformanceApiService) {}

  private assignedPerformanceToFeedback: Subject<
    PerformanceReview[]
  > = new Subject();
  $assignedPerformanceToFeedback: Observable<
    PerformanceReview[]
  > = this.assignedPerformanceToFeedback.asObservable();

  getAllPerformances(): void {
    this.apiService
      .getPerformances()
      .subscribe((p) => this.assignedPerformanceToFeedback.next(p));
  }
  getAssigned(): void {
    this.apiService
      .getPerformances(true)
      .subscribe((ap) => this.assignedPerformanceToFeedback.next(ap));
  }

  writeFeedback(feedback: Feedback): Observable<void> {
    return this.apiService.writeReview(feedback);
  }

  writePerformance(performance: WrittenPerformance): Observable<void> {
    return performance.id
      ? this.apiService.updatePerformance(performance)
      : this.apiService.addPerformance(performance);
  }

  assignEmployeeToPerformance(
    employeeId: string,
    performanceId: string
  ): Observable<void> {
    return this.apiService.assignEmployeeToPerformance(
      employeeId,
      performanceId
    );
  }
}
