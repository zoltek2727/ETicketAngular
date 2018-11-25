import { Component, OnInit, Inject } from '@angular/core';

import { Event } from "../models/event";
import { windowProvider } from '../window';
import { EventService } from '../services/events.service';

@Component({
  selector: 'app-event-search',
  templateUrl: './event-search.component.html',
})
export class EventSearchComponent implements OnInit {
  public events: Event[];

  constructor(private eventsService: EventService,
    @Inject(windowProvider.provide) private window: Window) { }

  ngOnInit() {
    this.eventsService.getEvents()
      .subscribe(events => {
        this.events = events;
      });
  }

}
