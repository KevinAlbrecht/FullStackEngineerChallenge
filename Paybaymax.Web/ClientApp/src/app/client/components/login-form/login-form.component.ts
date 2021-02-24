import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginResponse } from '@pay/client/models';
import { LoadingComponent } from '@pay/shared/models';

@Component({
  selector: 'pay-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginFormComponent extends LoadingComponent {
  hasLoginError = false;

  @Input() set loginResponse(value: LoginResponse | null) {
    this.isLoading = false;
    this.hasLoginError = value && value === LoginResponse.Failed ? true : false;
  }

  @Output() login = new EventEmitter();

  loginForm: FormGroup;

  constructor(fb: FormBuilder) {
    super();
    this.loginForm = fb.group({
      email: fb.control('', [Validators.required, Validators.email]),
      password: fb.control('', [Validators.required]),
    });
  }

  submitLogin(): void {
    if (!this.loginForm.invalid) {
      this.isLoading = true;
      this.login.emit(this.loginForm.value);
    }
  }
}
