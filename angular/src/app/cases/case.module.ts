// src/app/cases/case.module.ts
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModalModule, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';
import { CaseComponent } from './cases.component';
import { CaseRoutingModule } from './cases-routing.module';
import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  declarations: [CaseComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModalModule,
    NgbDatepickerModule,
    CaseRoutingModule,
    SharedModule,
    NgSelectModule
  ]
})
export class CaseModule { }
