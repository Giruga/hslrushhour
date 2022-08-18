import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DisruptionDto } from '../../models/Disruption';

@Injectable({
  providedIn: 'root',
})
export class DisruptionApi {
  private baseUrl = 'api/disruptions';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private httpClient: HttpClient) {}

  getDisruptions(): Observable<DisruptionDto[]> {
    return this.httpClient.get<DisruptionDto[]>(this.baseUrl);
  }
}
