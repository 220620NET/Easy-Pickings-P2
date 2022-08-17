import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LocalStorageService } from 'angular-web-storage';
import { User } from '../models/User';
import { AuthServiceService } from '../services/AuthService/auth-service.service';
import { Ticket } from '../models/Ticket';
@Component({
  selector: 'app-ticket-table',
  templateUrl: './ticket-table.component.html',
  styleUrls: ['./ticket-table.component.css']
})

export class TicketTableComponent implements OnInit {
  api:string = 'https://easy-pickings-p2.azurewebsites.net/';
  currentUser:User={
    userID: 0,
    firstName: '',
    middleInitial: '',
    lastName: '',
    username: '',
    password: '',
    DoB: '',
    role: ''
  };
  tickets:any=[]
  constructor(private http:HttpClient,private local:LocalStorageService, private auth:AuthServiceService) { }
  getTickets():void{
    this.http.get(this.api+`tickets/id/${this.currentUser.userID}`).subscribe((res)=>{
      this.tickets =res;
    });
  }
  ngOnInit(): void {
    this.currentUser = this.auth.getCurrentUser();
  }

}
