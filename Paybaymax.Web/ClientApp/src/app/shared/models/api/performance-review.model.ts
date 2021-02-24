import { LightEmployee } from '.';

export interface PerformanceReview {
  id: string;
  title: string;
  description: string;
  date: string;
  concerned: LightEmployee;
  assigned: LightEmployee[];
}
