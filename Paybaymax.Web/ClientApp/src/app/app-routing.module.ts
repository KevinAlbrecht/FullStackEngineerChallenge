import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AlreadyConnectedGuard, AuthGuard } from '@pay/shared/guards';
import { AdminPageComponent } from '@pay/admin/pages';
import {
  PerformancesPageComponent,
  LoginPageComponent,
} from './client/pages';
const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: LoginPageComponent,
    canActivate: [AlreadyConnectedGuard],
  },
  {
    path: 'dashboard',
    canActivate: [AuthGuard],
    component: PerformancesPageComponent,
    children: [],
  },
  {
    path: 'admin',
    canActivate: [AuthGuard],
    component: AdminPageComponent,
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
