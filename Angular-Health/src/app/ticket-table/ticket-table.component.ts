import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LocalStorageService } from 'angular-web-storage';
import { User } from '../models/User';
import { AuthServiceService } from '../services/AuthService/auth-service.service';
import { Ticket } from '../models/Ticket';
import { TicketServiceService } from '../services/TicketService/ticket-service.service';
import { _MatDialogContainerBase } from '@angular/material/dialog'; 
import { Router, RouteReuseStrategy } from '@angular/router';
import { FormBuilder, FormControl } from '@angular/forms';
@Component({
  selector: 'app-ticket-table',
  templateUrl: './ticket-table.component.html',
  styleUrls: ['./ticket-table.component.css']
})

export class TicketTableComponent implements OnInit {
  api:string = 'https://easy-pickings-p2.azurewebsites.net/';
  currentUser:User={
    userID: 0,
    first_name: '',
    middle_init: '',
    last_name: '',
    username: '',
    password: '',
    DoB: '',
    role: ''
  };
  displayedColumns:string[]=['demo-id', 'demo-user', 'demo-claim', 'demo-policy', 'demo-details', 'demo-update', 'demo-delete'];
  tickets:Ticket[] =[{
    ticketID:0,
    userID:0,
    claimID:0,
    policyID :0,
    details:'here'
  }]
  
  theme:string = 'light';
  constructor(private http:HttpClient,private local:LocalStorageService, private auth:AuthServiceService, private tick:TicketServiceService, private router:Router ) { }
  getTickets():void{
    this.tick.getTicketsByID(this.currentUser.userID).subscribe((res)=>{
      console.log(res);
      this.tickets=res;
    })
    }
    setTheme(a:string):void{
      this.theme = a;
      document.documentElement.className = this.theme;
    }
    updateTicket(tick:Ticket):void{
      this.local.set('ticketID',tick.ticketID);
      this.router.navigateByUrl('/update/ticket');
    }
    deleteTicket(tick:Ticket):void{ 
      if(confirm('Are you sure')){
        this.tick.deleteTick(tick.ticketID).subscribe((res)=>{
          this.getTickets()
        })
      }
    }
    routeHandler(a:string):void{
      this.router.navigateByUrl(`/${a}`)
    }
    logout():void{
      this.local.clear();
      if(this.auth.isAuthenticated()===false){
        this.routeHandler('login')
      }
    }
  ngOnInit(): void {
    this.currentUser = this.auth.getCurrentUser();
    this.getTickets();
  }

}
