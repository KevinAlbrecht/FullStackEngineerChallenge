import { NgModule } from '@angular/core';
import { AdminPageComponent } from '@pay/admin/pages';
import { CreatePerformanceComponent } from '@pay/admin/components';
import { SharedModule } from '@pay/shared/shared.module';

@NgModule({
  declarations: [AdminPageComponent, CreatePerformanceComponent],
  imports: [SharedModule],
})
export class AdminModule {}
