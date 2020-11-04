import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BuildingListComponent } from './building-list/building-list.component';
import { BuildingDetailComponent } from './building-detail/building-detail.component';

const routes: Routes = [
  { path: '', component: BuildingListComponent,  },
  { path: ':id', component: BuildingDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BuildingsRoutingModule { }