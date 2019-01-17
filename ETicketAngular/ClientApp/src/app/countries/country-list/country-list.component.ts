import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

import { Country } from "src/app/models/country";
import { windowProvider } from 'src/app/window'
import { CountriesService } from 'src/app/services/countries.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css']
})
export class CountryListComponent implements OnInit {
  public countries: Country[];
  dataSource: MatTableDataSource<Country>;
  displayedColumns: string[] = ['countryId', 'countryName'];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private countriesService: CountriesService,
    @Inject(windowProvider.provide) private window: Window, private router: Router) {
    this.countriesService.getCountries().subscribe(countries => { this.dataSource = new MatTableDataSource(countries); });
  }

  ngOnInit() {
    this.countriesService.getCountries().subscribe(countries => { this.dataSource = new MatTableDataSource(countries); });
    
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  public getCountryDetails(id) {
    let countryUrl: string = `/country-edit/${id}`;
    this.router.navigate([countryUrl]);
  }

}

