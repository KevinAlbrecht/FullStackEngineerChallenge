import { Injectable } from '@angular/core';
import { User } from '@pay/shared/models';
import { LocalStorageService } from './api/local-storage.service';

const CURRENT_USER_STORAGE_KEY = 'cu';

@Injectable({
  providedIn: 'root',
})
export class StorageService {
  constructor(private localStorageService: LocalStorageService) {}

  storeCurrentUser(user: User): void {
    this.localStorageService.set(CURRENT_USER_STORAGE_KEY, user);
  }
  getCurrentUser(): User | null {
    const str = this.localStorageService.get(CURRENT_USER_STORAGE_KEY);
    return str === null ? str : JSON.parse(str);
  }

  clear(): void {
    this.localStorageService.clear();
  }
}
