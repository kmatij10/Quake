import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Building } from './building';
import { BuildingListResponse } from './building-list/building-list.response';

@Injectable({
  providedIn: 'root'
})
export class BuildingService {

  constructor (
    private http: HttpClient
  ) { }

  getBuildings(params = {}) {
    // GET req na localhost:5001/api/buildings?search=abc
    return this.http.get<BuildingListResponse>(environment.apiUrl + '/buildings', { params });
  }

  saveBuilding(building: Building) {
    if(building.id) { return this.putBuilding(building); }
    return this.postBuilding(building);
  }

  getBuilding(id: number) {
    return this.http.get<Building>(environment.apiUrl + '/buildings/' + id);
  }

  deleteBuilding(id: number) {
    return this.http.delete(environment.apiUrl + '/buildings/' + id);
  }

  postBuilding(building: Building) {
    return this.http.post<Building>(environment.apiUrl + '/buildings', building);
  }

  putBuilding(building: Building) {
    return this.http.put<Building>(environment.apiUrl + '/buildings/' + building.id, building);
  }
}