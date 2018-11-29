import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Event } from "src/app/models/event";
import { Observable } from 'rxjs';

@Injectable()
export class EventService {

  constructor(private httpClient: HttpClient) { }

  // Getting the list of events
  getEvents(): Observable<Event[]> {
    return this.httpClient.get<Event[]>('/api/Events');
  }

  getEvent(id: string): Observable<Event> {
    return this.httpClient.get<Event>('/api/Events/' + id);
  }
}
