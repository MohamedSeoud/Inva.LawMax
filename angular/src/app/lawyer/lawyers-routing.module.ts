import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LawyerComponent } from './lawyers.component';
import { authGuard, permissionGuard } from '@abp/ng.core';

const routes: Routes = [
  { path: '', component: LawyerComponent, canActivate: [authGuard, permissionGuard] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LawyerRoutingModule {}
