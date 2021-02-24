import { Component, OnInit } from '@angular/core';
import { AuthService } from '@pay/shared/services';
import { LoginCredentials, LoginResponse } from '@pay/client/models';
import { Router } from '@angular/router';

@Component({
  selector: 'pay-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
})
export class LoginPageComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router) {}

  loginResponse: LoginResponse;

  onLogIn($event: LoginCredentials): void {
    this.loginResponse = null;
    this.authService.logIn($event.email, $event.password).subscribe(
      (u) => {
        this.loginResponse = LoginResponse.Succed;
        u.typeId === 1
          ? this.router.navigate(['/dashboard'])
          : this.router.navigate(['/admin']);
      },
      (error) => (this.loginResponse = LoginResponse.Failed)
    );
  }
  ngOnInit(): void {}
}
