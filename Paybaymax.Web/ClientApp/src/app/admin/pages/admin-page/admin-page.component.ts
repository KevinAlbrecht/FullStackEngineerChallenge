import { OnInit, Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PerformanceReviewItem } from '@pay/shared/components/performances-list/performance-review-item.model';
import {
  LightEmployee,
  PerformanceReview,
  WrittenPerformance,
} from '@pay/shared/models';
import { EmployeeService, PerformanceService } from '@pay/shared/services';
import { Observable } from 'rxjs';

@Component({
  selector: 'pay-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss'],
})
export class AdminPageComponent implements OnInit {
  private readonly assignEmployeeFormInitValue: { toAssign: string };
  private allEmployees: LightEmployee[];

  readonly $performanceReviews: Observable<PerformanceReview[]>;
  selectedPerformance: PerformanceReviewItem;
  currentPanel = 0;
  assignableEmployees: LightEmployee[];
  assignEmployeeForm: FormGroup;
  isAssignationDisabled = true;

  constructor(
    private performanceService: PerformanceService,
    fb: FormBuilder,
    private employeeService: EmployeeService
  ) {
    this.$performanceReviews = this.performanceService.$assignedPerformanceToFeedback;
    this.assignEmployeeForm = fb.group({
      toAssign: fb.control('', Validators.required),
    });
    this.assignEmployeeFormInitValue = this.assignEmployeeForm.value;
  }

  ngOnInit(): void {
    this.performanceService.getAllPerformances();
    this.employeeService
      .getAllEmployees()
      .subscribe({ next: (e) => (this.allEmployees = e) });
  }

  onDeselectPerformance(): void {
    this.selectedPerformance = null;
  }

  onPerformanceSelected(performance: PerformanceReviewItem): void {
    this.selectedPerformance = performance;
    this.assignEmployeeForm.reset(this.assignEmployeeFormInitValue);
    if (performance) {
      this.assignEmployeeForm.enable();
      this.assignableEmployees = this.getAssignableEmployees();
    } else {
      this.assignEmployeeForm.disable();
    }
  }

  onSubmitPerformance(performance: WrittenPerformance): void {
    if (this.selectedPerformance) {
      performance.id = this.selectedPerformance.id;
    }
    this.performanceService
      .writePerformance(performance)
      .subscribe((_) => this.performanceService.getAllPerformances());
  }

  onSubmitAssign(): void {
    if (!this.assignEmployeeForm.invalid) {
      this.performanceService
        .assignEmployeeToPerformance(
          this.assignEmployeeForm.value.toAssign,
          this.selectedPerformance.id
        )
        .subscribe((_) => this.performanceService.getAllPerformances());
    }
  }

  private getAssignableEmployees(): LightEmployee[] {
    // Static code ... to excluse non assignable employees

    const accessLowerId = (e: LightEmployee): string =>
      e.employeeId.toLowerCase();

    const selectedPerformanceConcerned = accessLowerId(
      this.selectedPerformance.concerned
    );

    return this.allEmployees.filter(
      (employee) =>
        accessLowerId(employee) !== selectedPerformanceConcerned &&
        this.selectedPerformance.assigned.findIndex(
          (e) => e.employeeId === accessLowerId(employee)
        ) === -1
    );
  }
}
