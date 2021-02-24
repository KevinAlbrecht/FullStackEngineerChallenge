import { NgModule } from '@angular/core';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { SharedModule } from '../shared/shared.module';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { PerformancesPageComponent } from './pages/performances-page/performances-page.component';

@NgModule({
  declarations: [
    LoginPageComponent,
    LoginFormComponent,
    PerformancesPageComponent,
  ],
  imports: [SharedModule],
})
export class ClientModule {}
