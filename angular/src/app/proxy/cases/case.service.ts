import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateUpdateCaseDto, CaseDto } from './models';

@Injectable({
  providedIn: 'root',
})
export class CaseService {
  private apiUrl = 'https://localhost:44317/api/app/cases';

  constructor(private http: HttpClient) {}

  getList(): Observable<CaseDto[]> {
    return this.http.get<CaseDto[]>(this.apiUrl);
  }

  get(id: string): Observable<CaseDto> {
    return this.http.get<CaseDto>(`${this.apiUrl}/${id}`);
  }

  create(input: CreateUpdateCaseDto): Observable<CaseDto> {
    return this.http.post<CaseDto>(this.apiUrl, input);
  }

  update(id: string, input: CreateUpdateCaseDto): Observable<CaseDto> {
    return this.http.put<CaseDto>(`${this.apiUrl}/${id}`, input);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
