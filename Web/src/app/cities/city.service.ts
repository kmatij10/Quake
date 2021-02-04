import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { City } from './city';

@Injectable({
    providedIn: 'root'
})
export class CityService {

    constructor (
        private http: HttpClient
    ) { }

    getCities(params = {}) {
        return this.http.get<City[]>(environment.apiUrl + '/cities', { params });
    }
}