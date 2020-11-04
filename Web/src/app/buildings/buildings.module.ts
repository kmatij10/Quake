import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BuildingsRoutingModule } from './buildings-routing.module';
import { BuildingListComponent } from './building-list/building-list.component';
import { BuildingDetailComponent } from './building-detail/building-detail.component';
import { HttpClientModule } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [BuildingListComponent, BuildingDetailComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule,
    BuildingsRoutingModule,
    FormsModule,
    NgxPaginationModule
  ]
})
export class BuildingsModule { }