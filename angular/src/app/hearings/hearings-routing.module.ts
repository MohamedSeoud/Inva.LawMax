// src/app/hearings/hearings-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HearingComponent } from './hearings.component';

const routes: Routes = [{ path: '', component: HearingComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HearingRoutingModule {}
