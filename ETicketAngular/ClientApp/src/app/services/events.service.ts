import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Event } from "../models/event";

@Injectable()
export class EventService {

  constructor(private httpClient: HttpClient) { }

  // Getting the list of events
  getEvents(): Observable<Event[]> {
    return this.httpClient.get<Event[]>('/api/Events');
  }
}
