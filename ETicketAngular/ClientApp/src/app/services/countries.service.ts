import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Country } from "src/app/models/country";
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable()
export class CountriesService {

  constructor(private httpClient: HttpClient) { }

  getCountries(): Observable<Country[]> {
    return this.httpClient.get<Country[]>('/api/Countries');
  }

  getCountry(id: string): Observable<Country> {
    return this.httpClient.get<Country>('/api/Countries/' + id);
  }

  addCountry(country: Country): Observable<Country> {
    return this.httpClient.post<Country>('/api/Countries/', country, httpOptions);
  }

  deleteCountry(id: string): Observable<{}> {
    return this.httpClient.delete('/api/Countries/' + id, httpOptions);
  }

  updateCountry(id: string): Observable<Country> {
    return this.httpClient.put<Country>('/api/Countries/' + id, httpOptions);
  }
}
