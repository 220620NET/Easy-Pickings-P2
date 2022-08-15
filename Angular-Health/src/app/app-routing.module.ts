import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
<<<<<<< HEAD
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
  {path: 'profile',component:ProfileComponent}
=======
import { StartScreenComponent } from './start-screen/start-screen.component';
import { HomePageComponent } from './home-page/home-page.component';
import { HealthServicesService } from './services/health-services.service';
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
  },
  {path: '*', redirectTo: '/login', pathMatch: 'full'}
>>>>>>> d3967b7e6c5af1345b757baf7bf168e1166d442f
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
