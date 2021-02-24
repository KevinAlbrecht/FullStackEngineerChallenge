import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { TranslateModule } from '@ngx-translate/core';
import { AuthApiService, LocalStorageService } from '@pay/shared/services/api';
import { PerformancesListComponent } from '@pay/shared/components';
import { RatingComponent } from './components/rating/rating.component';
import { CreateFeedbackComponent } from '../client/components/create-feedback/create-feedback.component';

@NgModule({
  declarations: [
    PerformancesListComponent,
    RatingComponent,
    CreateFeedbackComponent,
    RatingComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    TranslateModule.forChild(),
    ReactiveFormsModule,
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule,
    TranslateModule,
    PerformancesListComponent,
    RatingComponent,
    CreateFeedbackComponent,
  ],
  providers: [AuthApiService, LocalStorageService],
})
export class SharedModule {}
