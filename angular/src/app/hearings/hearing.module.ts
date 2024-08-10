// src/app/hearings/hearing.module.ts
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';
import { HearingComponent } from './hearings.component';
import { HearingRoutingModule } from './hearings-routing.module';
import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  declarations: [HearingComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModalModule,
    NgSelectModule,
    SharedModule,
    HearingRoutingModule,
  ],
})
export class HearingModule {}
