import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Event } from "src/app/models/event";
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable()
export class EventService {

  constructor(private httpClient: HttpClient) { }

  getEvents(): Observable<Event[]> {
    return this.httpClient.get<Event[]>('/api/Events');
  }

  getEvent(id: string): Observable<Event> {
    return this.httpClient.get<Event>('/api/Events/' + id);
  }

  addEvent(event: Event): Observable<Event> {
    return this.httpClient.post<Event>('/api/Events/', event, httpOptions);
  }

  deleteEvent(id: string): Observable<{}> {
    return this.httpClient.delete('/api/Events/' + id, httpOptions);
  }

  updateEvent(id: string): Observable<Event> {
    return this.httpClient.put<Event>('/api/Events/' + id, httpOptions);
  }
}
