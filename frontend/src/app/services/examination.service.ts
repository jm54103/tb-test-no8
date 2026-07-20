import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Examination } from '../models/examination';

@Injectable({
  providedIn: 'root'
})
export class ExaminationService {

  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5000/api/Examination';

  getQuestions() {
    return this.http.get<Examination[]>(this.apiUrl);
  }

  createExamination(examinationData: Examination): Observable<Examination> {
    return this.http.post<Examination>(this.apiUrl, examinationData);
  }

  deleteQuestion(id: number | string): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
  
}