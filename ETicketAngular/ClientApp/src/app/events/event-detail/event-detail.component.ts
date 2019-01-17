import { Component, OnInit, Inject } from '@angular/core';

import { Event } from "src/app/models/event";
import { EventService } from 'src/app/services/events.service';
import { windowProvider } from 'src/app/window';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.css']
})
export class EventDetailComponent implements OnInit {
  public event: Event;

  constructor(private eventsService: EventService,
    private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getEventDetails()
  }

  getEventDetails() {
    let id: string = this.activeRoute.snapshot.params['id'];

    this.eventsService.getEvent(id)
      .subscribe(event => {
        this.event = event as Event;
      })
  }

}
