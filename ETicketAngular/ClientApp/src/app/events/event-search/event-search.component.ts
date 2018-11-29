import { Component, OnInit, Inject } from '@angular/core';

import { Event } from "src/app/models/event";
import { windowProvider } from 'src/app/window'
import { EventService } from '../services/events.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-search',
  templateUrl: './event-search.component.html',
  styleUrls: ['./event-search.component.css']
})
export class EventSearchComponent implements OnInit {
  public events: Event[];
  splicedData: Event[];
  pageLength: number;
  pageSize: number;

  constructor(private eventsService: EventService,
    @Inject(windowProvider.provide) private window: Window, private router: Router) { }

  ngOnInit() {
    this.eventsService.getEvents()
      .subscribe(events => {
        this.events = events;
        this.pageSize = 8;
        this.pageLength = events.length;
        this.splicedData = events.slice(((0 + 1) - 1) * this.pageSize).slice(0, this.pageSize);
      });
  }

  public getEventDetails(id) {
    let eventUrl: string = `/event-detail/${id}`;
    this.router.navigate([eventUrl]);
  }

  pageChangeEvent(event) {
    const offset = ((event.pageIndex + 1) - 1) * event.pageSize;
    this.splicedData = this.events.slice(offset).slice(0, event.pageSize);
  }
}
