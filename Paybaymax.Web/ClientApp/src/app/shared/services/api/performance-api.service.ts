import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import {
  Feedback,
  PerformanceReview,
  User,
  WrittenPerformance,
} from '../../models';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PerformanceApiService {
  private readonly perfsUrl = `${environment.api.baseUrl}performance/`;
  private readonly assignedPerfs = `${this.perfsUrl}assigned`;
  private readonly assignToPerfs = `${this.perfsUrl}assign`;
  private readonly writeReviewUrl = `${environment.api.baseUrl}feedback`;

  constructor(private http: HttpClient) {}

  getPerformances(onlyAssigned = false): Observable<PerformanceReview[]> {
    const url = onlyAssigned ? this.assignedPerfs : this.perfsUrl;
    return this.http.get<PerformanceReview[]>(url);
  }

  writeReview(feedback: Feedback): Observable<void> {
    return this.http.post<void>(this.writeReviewUrl, feedback);
  }
  addPerformance(perf: WrittenPerformance): Observable<void> {
    return this.http.post<void>(this.perfsUrl, perf);
  }
  updatePerformance(perf: WrittenPerformance): Observable<void> {
    return this.http.put<void>(this.perfsUrl + perf.id, perf);
  }
  assignEmployeeToPerformance(
    employeeId: string,
    performanceId: string
  ): Observable<void> {
    return this.http.post<void>(this.assignToPerfs, {
      employeeId,
      performanceId,
    });
  }
}
