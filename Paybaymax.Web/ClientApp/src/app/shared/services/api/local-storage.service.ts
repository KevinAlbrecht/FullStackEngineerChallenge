import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LocalStorageService {
  constructor() {}

  set(key: string, value: any | string): void {
    let stringifiedValue: string;
    if (typeof value !== 'string') {
      stringifiedValue = JSON.stringify(value);
    } else {
      stringifiedValue = value;
    }
    localStorage.setItem(key, stringifiedValue);
  }

  get(key: string): string | null {
    return localStorage.getItem(key);
  }

  clear(): void {
    localStorage.clear();
  }
}
