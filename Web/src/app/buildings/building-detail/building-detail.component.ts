import { Component, OnInit } from '@angular/core';
import { Building } from '../building';
import { BuildingService } from '../building.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-building-detail',
  templateUrl: './building-detail.component.html',
  styleUrls: ['./building-detail.component.scss']
})
export class BuildingDetailComponent implements OnInit {

  building?: Building;
  id!: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private buildingService: BuildingService
  ) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
        this.id = Number(params.get('id'));
        this.loadBuilding();
    });
  }

  loadBuilding() {
    this.buildingService
      .getBuilding(this.id)
      .subscribe(result => {
        this.building = result;
      });
  }

}