import { Component, OnInit } from '@angular/core';
import { BuildingService } from '../building.service';

import * as Leaflet from 'leaflet';
import { BuildingListResponse } from './building-list.response';
import { Building } from '../building';

@Component({
  selector: 'app-building-list',
  templateUrl: './building-list.component.html',
  styleUrls: ['./building-list.component.scss']
})
export class BuildingListComponent implements OnInit {

  /* view model -> buildings and metadata are loaded here */
  vm: BuildingListResponse = { page: 1 } as BuildingListResponse;
  searchText?: string;
  map: Leaflet.Map;

  constructor(
    private buildingService: BuildingService
  ) { }

  ngOnInit(): void {
    this.loadBuildings();
  }

  loadBuildings() {
    let params: any = { page: this.vm?.page || 1 };
    if(this.searchText) { params.search = this.searchText; }

    this.buildingService
      .getBuildings(params)
      .subscribe(response => {
        this.vm = response;
        this.initMap();
    });
  }

  initMap() {
    this.map = Leaflet.map('map').setView([45.800440, 15.994100], 14);
    Leaflet.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: 'edupala.com © Angular LeafLet',
    }).addTo(this.map);

    var greenIcon = Leaflet.icon({
      iconUrl: 'https://leafletjs.com/examples/custom-icons/leaf-green.png',
      shadowUrl: 'https://leafletjs.com/examples/custom-icons/leaf-shadow.png',
  
      iconSize:     [38, 95], // size of the icon
      shadowSize:   [50, 64], // size of the shadow
      iconAnchor:   [22, 94], // point of the icon which will correspond to marker's location
      shadowAnchor: [4, 62],  // the same for the shadow
      popupAnchor:  [-3, -76] // point from which the popup should open relative to the iconAnchor
    });
    var redIcon = Leaflet.icon({
      iconUrl: 'https://leafletjs.com/examples/custom-icons/leaf-red.png',
      shadowUrl: 'https://leafletjs.com/examples/custom-icons/leaf-shadow.png',
  
      iconSize:     [38, 95], // size of the icon
      shadowSize:   [50, 64], // size of the shadow
      iconAnchor:   [22, 94], // point of the icon which will correspond to marker's location
      shadowAnchor: [4, 62],  // the same for the shadow
      popupAnchor:  [-3, -76] // point from which the popup should open relative to the iconAnchor
    });
    var yellowIcon = Leaflet.icon({
      iconUrl: 'https://leafletjs.com/examples/custom-icons/leaf-orange.png',
      shadowUrl: 'https://leafletjs.com/examples/custom-icons/leaf-shadow.png',
  
      iconSize:     [38, 95], // size of the icon
      shadowSize:   [50, 64], // size of the shadow
      iconAnchor:   [22, 94], // point of the icon which will correspond to marker's location
      shadowAnchor: [4, 62],  // the same for the shadow
      popupAnchor:  [-3, -76] // point from which the popup should open relative to the iconAnchor
    });

    this.vm.buildings.forEach(element => {
      if (element.cardId == 3) {
        Leaflet.marker([element.lat,element.lng],{icon: greenIcon}).bindPopup(this.getPopupText(element)).addTo(this.map); 
      } 
      else if (element.cardId == 2) {
        Leaflet.marker([element.lat,element.lng],{icon: yellowIcon}).bindPopup(this.getPopupText(element)).addTo(this.map);
      }
      else if (element.cardId == 1) {
        Leaflet.marker([element.lat,element.lng],{icon: redIcon}).bindPopup(this.getPopupText(element)).addTo(this.map);
      }
    });
  }

  getPopupText(building: Building): string {
    let result = `Building ${building.id}<br />`;
    result += `Address: <b>${building.address}</b><br />`;
    result += `View <a href="${this.getPopupLink(building)}">Details</a>`
    return result;
  }

  getPopupLink(building: Building): string {
    return `${window.location.href}/${building.id}`;
  }

}