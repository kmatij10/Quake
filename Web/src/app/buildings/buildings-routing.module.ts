import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BuildingListComponent } from './building-list/building-list.component';
import { BuildingDetailComponent } from './building-detail/building-detail.component';
import { BuildingFormComponent } from './building-form/building-form.component';

const routes: Routes = [
  { path: '', component: BuildingListComponent,  },
  { path: 'new', component: BuildingFormComponent},
  { path: ':id', component: BuildingDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BuildingsRoutingModule { }