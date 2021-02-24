import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { User } from '../../models';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthApiService {
  private readonly authUrl = `${environment.api.baseUrl}auth/`;
  private readonly logoutUrl = `${environment.api.baseUrl}auth/logout`;

  constructor(private http: HttpClient) {}

  postLogIn(email: string, password: string): Observable<User> {
    return this.http.post<User>(this.authUrl, { email, password });
  }

  logOut(): Promise<void> {
    return this.http.post<void>(this.logoutUrl, null).toPromise();
  }
}
