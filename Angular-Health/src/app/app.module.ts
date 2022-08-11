import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StartScreenComponent } from './start-screen/start-screen.component';
import { HomePageComponent } from './home-page/home-page.component';
import { ProfileComponent } from './profile/profile.component';
import { ClaimTableComponent } from './claim-table/claim-table.component';
import { PolicyTableComponent } from './policy-table/policy-table.component';
import { TicketTableComponent } from './ticket-table/ticket-table.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    StartScreenComponent,
    HomePageComponent,
    ProfileComponent,
    ClaimTableComponent,
    PolicyTableComponent,
    TicketTableComponent, 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }