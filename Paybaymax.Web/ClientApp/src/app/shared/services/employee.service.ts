import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeApiService } from './api/employee-api.service';
import { LightEmployee } from '@pay/shared/models';

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  constructor(private apiService: EmployeeApiService) {}

  getAllEmployees(): Observable<LightEmployee[]> {
    return this.apiService.getALlEmployees();
  }
}
