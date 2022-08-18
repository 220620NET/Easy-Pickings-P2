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
import { AppEditPolicyComponent } from './policy-table/app-edit-policy/app-edit-policy.component';
import { ContactTableComponent } from './contact-table/contact-table.component';
import { AddEditContactComponent } from './contact-table/add-edit-contact/add-edit-contact.component';
import { AddEditClaimComponent } from './claim-table/add-edit-claim/add-edit-claim.component';
const routes: Routes = [
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
    path:'update/policy',
    component:AppEditPolicyComponent
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
    path:'update/claim',
    component:AddEditClaimComponent
  },{
    path:'profile',
    component:ProfileComponent
  },{
    path:'update/ticket',
    component: AddEditComponent
  },{
    path:'contact',
    component:ContactTableComponent
  },{
    path:'update/contact',
    component:AddEditContactComponent
  },{
    path: '*', 
    redirectTo: '/login', 
    pathMatch: 'full'
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
