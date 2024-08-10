import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateUpdateLawyerDto, LawyerDto } from './models';

@Injectable({
  providedIn: 'root',
})
export class LawyerService {
  apiUrl = 'https://localhost:44317/api/app/lawyers';

  constructor(private http: HttpClient) {}

  getList(): Observable<LawyerDto[]> {
    return this.http.get<LawyerDto[]>(this.apiUrl) as Observable<LawyerDto[]>;
  }

  get(id: string): Observable<LawyerDto> {
    return this.http.get<LawyerDto>(`${this.apiUrl}/${id}`);
  }

  create(input: CreateUpdateLawyerDto): Observable<LawyerDto> {
    return this.http.post<LawyerDto>(this.apiUrl, input);
  }

  update(id: string, input: CreateUpdateLawyerDto): Observable<LawyerDto> {
    return this.http.put<LawyerDto>(`${this.apiUrl}/${id}`, input);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
