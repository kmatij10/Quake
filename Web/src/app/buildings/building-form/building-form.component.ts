import { Component, OnInit } from '@angular/core';
import { Building } from '../building';
import { BuildingService } from '../building.service';

import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import * as jsonPatch from 'fast-json-patch';



@Component({
  selector: 'app-building-form',
  templateUrl: './building-form.component.html',
  styleUrls: ['./building-form.component.scss']
})
export class BuildingFormComponent implements OnInit {

  id: number = 0;

  buildingForm = this.fb.group({
    id: [''],
    address: [''],
    lat: [''],
    lng: [''],
    description: [''],
    cityId: [''],
    cardId: ['']
  });

  errors: any = {};

  constructor(
    private buildingService: BuildingService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
      this.id = Number(params.get('id'));
      this.loadBuilding();
    });

  }

  onSubmit() {
    let newBuilding = this.buildingForm.value;

    return this.buildingService.saveBuilding(newBuilding)
      .subscribe(
        result => this.onBuildingSave(result),
        result => this.onError(result.error)
      );
  }

  onError(response: any) {
    this.errors = response.errors;
  }

  onBuildingSave(result: Building) {

    /* redirect */
    let buildingId = result.id;
    this.router.navigate(['buildings/' + buildingId]);
  }

  loadBuilding() {
    if(!this.id) { return; }
    this.buildingService.getBuilding(this.id)
        .subscribe(building => {
          this.buildingForm.patchValue(building);
        });
  }

}