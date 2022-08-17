import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProfileComponent } from './profile/profile.component';


import { StartScreenComponent } from './start-screen/start-screen.component';
import { HomePageComponent } from './home-page/home-page.component';
import { HealthServicesService } from './services/health-services.service';
import { TicketTableComponent } from './ticket-table/ticket-table.component';
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
  },
  {
    path: 'login',
    component:StartScreenComponent
  },{
    path: 'ticket',
    component:TicketTableComponent
  },
  {path: '*', redirectTo: '/login', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
