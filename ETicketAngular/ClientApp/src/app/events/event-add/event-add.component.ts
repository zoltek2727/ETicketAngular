import { Component, OnInit, Inject } from '@angular/core';

import { Event } from "src/app/models/event";
import { EventService } from 'src/app/services/events.service';
import { windowProvider } from 'src/app/window';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event-add',
  templateUrl: './event-add.component.html',
  styleUrls: ['./event-add.component.css']
})
export class EventAddComponent implements OnInit {
  public events: Event[];

  constructor(private eventsService: EventService,
    @Inject(windowProvider.provide) private window: Window, private router: Router, private activeRoute: ActivatedRoute) { }

  model = new Event();

  ngOnInit() { }

  AddEvent(newEvent: Event): void {
    this.eventsService.addEvent(newEvent)
      .subscribe(event => this.events.push(event));
  }

}
