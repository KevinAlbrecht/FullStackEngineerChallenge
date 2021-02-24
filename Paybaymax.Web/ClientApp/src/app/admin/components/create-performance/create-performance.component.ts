import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PerformanceReviewItem } from '@pay/shared/components/performances-list/performance-review-item.model';
import { LightEmployee, WrittenPerformance } from '@pay/shared/models';
import { EmployeeService } from '@pay/shared/services';

@Component({
  selector: 'pay-create-performance',
  templateUrl: './create-performance.component.html',
  styleUrls: ['./create-performance.component.scss'],
})
export class CreatePerformanceComponent implements OnInit {
  private formInitValue;
  private _selectedPerformance: PerformanceReviewItem;

  @Output()
  submitPerformance: EventEmitter<WrittenPerformance> = new EventEmitter();

  @Input() set selectedPerformance(value: PerformanceReviewItem) {
    let resetValue = this.formInitValue;
    if (value) {
      resetValue = {
        title: value.title,
        description: value.description,
        date: this.formatDate(value.date),
        concerned: value.concerned.employeeId,
      };
    }
    this.performanceForm.reset(resetValue);
    this._selectedPerformance = value;
  }

  get hasSelectedPerformance(): boolean {
    return (
      this._selectedPerformance !== null &&
      this._selectedPerformance !== undefined
    );
  }

  employees: LightEmployee[];

  performanceForm: FormGroup;

  constructor(fb: FormBuilder, private employeeService: EmployeeService) {
    this.performanceForm = fb.group({
      title: fb.control('', Validators.required),
      description: fb.control('', Validators.required),
      date: fb.control(Date.now, [Validators.required]),
      concerned: fb.control('', Validators.required),
    });
    this.formInitValue = this.performanceForm.value;
  }
  ngOnInit(): void {
    this.employeeService
      .getAllEmployees()
      .subscribe({ next: (e) => (this.employees = e) });
  }

  submitWriteperformance(): void {
    if (!this.performanceForm.invalid) {
      this.submitPerformance.emit(this.performanceForm.value);
    }
  }

  private formatDate(d: string): string {
    const date = new Date(d);
    const month = date.getMonth() + 1;
    const day = date.getDate();

    return `${date.getFullYear()}-${this.padStartDate(
      month
    )}-${this.padStartDate(day)}`;
  }

  private padStartDate(dateElement: number): string {
    return dateElement.toString().padStart(2, '0');
  }
}
