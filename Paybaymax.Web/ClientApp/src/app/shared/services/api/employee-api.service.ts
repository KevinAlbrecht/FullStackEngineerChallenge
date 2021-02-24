import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { LightEmployee } from '@pay/shared/models';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class EmployeeApiService {
  private readonly employeesUrl = `${environment.api.baseUrl}employee/`;
  private readonly allEmployeesUrl = `${this.employeesUrl}all/`;

  constructor(private http: HttpClient) {}

  getALlEmployees(): Observable<LightEmployee[]> {
    return this.http.get<LightEmployee[]>(this.allEmployeesUrl);
  }
}
