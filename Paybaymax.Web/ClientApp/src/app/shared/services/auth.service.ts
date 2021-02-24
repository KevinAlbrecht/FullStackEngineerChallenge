import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { User } from '../models/api';
import { StorageService } from './storage.service';
import { AuthApiService } from './api';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly currentUser: BehaviorSubject<User | null>;

  readonly $currentUser: Observable<User | null>;

  constructor(
    private apiService: AuthApiService,
    private storageService: StorageService,
    private router: Router
  ) {
    const userInStorage: User | null = this.storageService.getCurrentUser();
    this.currentUser = new BehaviorSubject(userInStorage);
    this.$currentUser = this.currentUser.asObservable();
  }

  logIn(email: string, password: string): Observable<User> {
    return this.apiService.postLogIn(email, password).pipe(
      tap((u) => {
        this.storageService.storeCurrentUser(u);
        this.currentUser.next(u);
      })
    );
  }

  logOut(): Promise<void> {
    this.currentUser.next(null);
    this.storageService.clear();
    this.router.navigate(['login']);
    return this.apiService.logOut();
  }
}
