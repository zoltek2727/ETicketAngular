import { Component, OnInit, Inject } from '@angular/core';

import { Country } from "src/app/models/country";
import { CountriesService } from 'src/app/services/countries.service';
import { windowProvider } from 'src/app/window';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-country-add',
  templateUrl: './country-add.component.html',
  styleUrls: ['./country-add.component.css']
})
export class CountryAddComponent implements OnInit {
  public countries: Country[];

  constructor(private countriesService: CountriesService,
    @Inject(windowProvider.provide) private window: Window, private router: Router, private activeRoute: ActivatedRoute) { }

  model = new Country();

  ngOnInit() { }

  AddCountry(newCountry: Country): void {
    this.countriesService.addCountry(newCountry)
      .subscribe(country => this.countries.push(country));
  }

}
