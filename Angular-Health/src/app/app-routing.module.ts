import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProfileComponent } from './profile/profile.component';


import { StartScreenComponent } from './start-screen/start-screen.component';
import { HomePageComponent } from './home-page/home-page.component';
import { HealthServicesService } from './services/health-services.service';
import { TicketTableComponent } from './ticket-table/ticket-table.component';
import { PolicyTableComponent } from './policy-table/policy-table.component';
import { ClaimTableComponent } from './claim-table/claim-table.component';
import { AddEditComponent } from './ticket-table/add-edit/add-edit.component';
const routes: Routes = [
  {path: 'policy', component: PolicyTableComponent},
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
  {
    path:'main',
    component:HomePageComponent,
    canActivate:[HealthServicesService]
  },{
    path:'policy',
    component:PolicyTableComponent
  },{
    path: 'login',
    component:StartScreenComponent
  },{
    path: 'ticket',
    component:TicketTableComponent
  },{
    path:'claim',
    component:ClaimTableComponent
  },{
    path:'profile',
    component:ProfileComponent
  },{
    path:'update/ticket',
    component: AddEditComponent
  },
  {path: '*', redirectTo: '/login', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
