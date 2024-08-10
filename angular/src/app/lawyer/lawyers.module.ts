import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { LawyerRoutingModule } from './lawyers-routing.module';
import { LawyerComponent } from './lawyers.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [LawyerComponent],
  imports: [
    LawyerRoutingModule,
    SharedModule,
    NgbDatepickerModule,
  ]
})
export class LawyerModule {}
