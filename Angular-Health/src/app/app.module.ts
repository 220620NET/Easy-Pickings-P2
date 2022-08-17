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
import { AngularWebStorageModule } from 'angular-web-storage';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { DiscussionService } from './discussion.service';
import { AddEditDiscussionComponent } from './home-page/add-edit-discussion/add-edit-discussion.component';
import { FormsModule } from '@angular/forms';
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import { AddEditComponent } from './ticket-table/add-edit/add-edit.component';
import { ShowDiscussionComponent } from './home-page/show-discussion/show-discussion.component';


@NgModule({
  declarations: [
    AppComponent,
    StartScreenComponent,
    HomePageComponent,
    ProfileComponent,
    ClaimTableComponent,
    PolicyTableComponent,
    TicketTableComponent,
    AddEditDiscussionComponent,
    AddEditComponent,
    ShowDiscussionComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    AngularWebStorageModule, 
    MatButtonModule,
    MatCardModule,
    MatDialogModule,
    MatFormFieldModule,
    FormsModule,
    MatInputModule,
    MatTableModule,
    MatIconModule
  ],
  providers: [DiscussionService],
  bootstrap: [AppComponent]
})
export class AppModule { }