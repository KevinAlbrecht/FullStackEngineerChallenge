import { AbstractControl, ValidatorFn } from '@angular/forms';

const passwordValidationRegexp: RegExp = /d/i;

export function passwordValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: string } | null => {
    const passRegexp = passwordValidationRegexp.test(control.value);
    return passRegexp ? { invalidPassword: 'insecure' } : null;
  };
}
