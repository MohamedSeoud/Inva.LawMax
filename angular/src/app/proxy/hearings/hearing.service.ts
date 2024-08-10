// src/app/proxy/hearings/hearing.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HearingDto, CreateUpdateHearingDto } from './models';

@Injectable({
  providedIn: 'root',
})
export class HearingService {
  private apiUrl = 'https://localhost:44317/api/app/hearings';

  constructor(private http: HttpClient) {}

  getList(): Observable<HearingDto[]> {
    return this.http.get<HearingDto[]>(this.apiUrl);
  }

  get(id: string): Observable<HearingDto> {
    return this.http.get<HearingDto>(`${this.apiUrl}/${id}`);
  }

  create(input: CreateUpdateHearingDto): Observable<HearingDto> {
    return this.http.post<HearingDto>(this.apiUrl, input);
  }

  update(id: string, input: CreateUpdateHearingDto): Observable<HearingDto> {
    return this.http.put<HearingDto>(`${this.apiUrl}/${id}`, input);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
