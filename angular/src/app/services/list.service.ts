import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Paginator } from './paginator';
import { Sorter } from './sorter';

@Injectable({
  providedIn: 'root',
})
export class ListService<T> {
  paginator = new Paginator();
  sorter = new Sorter();
  isLoading$ = new BehaviorSubject<boolean>(false);

  constructor() {
    // Initialization logic
  }
}
