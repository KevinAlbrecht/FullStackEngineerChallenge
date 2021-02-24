import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LightEmployee, User } from './shared/models';
import { AuthService } from './shared/services';

@Component({
  selector: 'pay-banner',
  template: `<div id="banner">
    <div id="banner__content">
      <span id="banner__title">{{ 'common.appName' | translate }}</span>
      <div id="banner__links" *ngIf="user !== null">
        <a [routerLink]="['/dashboard']">{{
          'banner.dashboardLink' | translate
        }}</a>
        <a [hidden]="user.typeId === 1" [routerLink]="['/admin']">{{
          'banner.adminLink' | translate
        }}</a>
      </div>
      <span [hidden]="user === null">{{
        'banner.hello' | translate: { firstName: user?.firstName }
      }}</span>
      <button [hidden]="user === null" (click)="logout()">Log out</button>
    </div>
  </div>`,
  styles: [
    `
      #banner {
        margin-top: 5px;
        height: 50px;
        width: 100%;
        background-color: #417043;
        color: white;
        border-radius: 5px;
      }
      #banner__content {
        height: 100%;
        align-items: center;
        display: flex;
        flex-direction: row;
        justify-content: flex-start;
        padding: 0 30px;
      }

      #banner__links {
        flex: 1;
      }
      a {
        text-decoration: underline;
        color: white;
      }
      #banner__links a,
      #banner__links span {
        margin-left: 10px;
      }
      button {
        background: none;
        outline: none;
        border: 1px solid #fff;
        border-radius: 5px;
        padding: 5px;
        color: white;
        margin-left: 10px;
      }
      button:hover {
        background: white;
        color: #417043;
        cursor: pointer;
      }
    `,
  ],
})
export class BannerComponent {
  user: User | null;

  constructor(private router: Router, private authService: AuthService) {
    authService.$currentUser.subscribe((u) => (this.user = u));
  }

  logout(): void {
    this.authService.logOut().then((_) => this.router.navigate(['/login']));
  }
}
