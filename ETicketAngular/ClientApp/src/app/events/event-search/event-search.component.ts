import { Component, OnInit, Inject } from '@angular/core';

import { Event } from "src/app/models/event";
import { Country } from "src/app/models/country";
import { PerformerCategory } from 'src/app/models/performercategory';
import { windowProvider } from 'src/app/window'
import { EventService } from 'src/app/services/events.service';
import { CountriesService } from 'src/app/services/countries.service';
import { PerformerCategoriesService } from 'src/app/services/performercategories.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-search',
  templateUrl: './event-search.component.html',
  styleUrls: ['./event-search.component.css']
})
export class EventSearchComponent implements OnInit {
  public events: Event[];
  public countries: Country[];
  public performerCategories: PerformerCategory[];

  splicedData: Event[];
  pageLength: number;
  pageSize: number;

  constructor(private eventsService: EventService, private countriesService: CountriesService,
    private performerCategoriesService: PerformerCategoriesService,
    @Inject(windowProvider.provide) private window: Window, private router: Router) { }

  ngOnInit() {
    this.eventsService.getEvents()
      .subscribe(events => {
        this.events = events;
        this.pageSize = 8;
        this.pageLength = events.length;
        this.splicedData = events.slice(((0 + 1) - 1) * this.pageSize).slice(0, this.pageSize);
      });
    this.countriesService.getCountries().subscribe(countries => { this.countries = countries; });
    this.performerCategoriesService.getPerformerCategories().subscribe(performerCategories => { this.performerCategories = performerCategories; });
  }

  public getEventDetails(id) {
    let eventUrl: string = `/event-detail/${id}`;
    this.router.navigate([eventUrl]);
  }

  public deleteThisEvent(id): void {
    this.events = this.events.filter(h => h.EventId !== id);
    this.eventsService.deleteEvent(id).subscribe();
  }

  pageChangeEvent(event) {
    const offset = ((event.pageIndex + 1) - 1) * event.pageSize;
    this.splicedData = this.events.slice(offset).slice(0, event.pageSize);
  }
}
