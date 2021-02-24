import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoadingComponent, WrittenFeedback } from '@pay/shared/models';

@Component({
  selector: 'pay-create-feedback',
  templateUrl: './create-feedback.component.html',
  styleUrls: ['./create-feedback.component.scss'],
})
export class CreateFeedbackComponent extends LoadingComponent {
  private readonly formInitValue: WrittenFeedback;

  @Input() set disabled(value: boolean) {
    if (value === true) {
      this.feedbackForm.disable();
    } else {
      this.feedbackForm.enable();
    }
  }
  @Output() submitFeedback: EventEmitter<WrittenFeedback> = new EventEmitter();
  feedbackForm: FormGroup;

  constructor(fb: FormBuilder) {
    super();
    this.feedbackForm = fb.group({
      quality: fb.control(1, Validators.required),
      initiative: fb.control(1, Validators.required),
      cooperation: fb.control(1, Validators.required),
      comment: fb.control(''),
    });
    this.formInitValue = this.feedbackForm.value;
  }

  submitWriteFeedback(): void {
    const feedback: WrittenFeedback = {
      cooperation: this.feedbackForm.value.cooperation,
      quality: this.feedbackForm.value.quality,
      initiative: this.feedbackForm.value.initiative,
      comment: this.feedbackForm.value.comment,
    };
    this.isLoading = true;
    this.submitFeedback.emit(feedback);
    this.feedbackForm.reset(this.formInitValue);
  }
}
