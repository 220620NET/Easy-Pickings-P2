import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService } from 'angular-web-storage';
import { Observable } from 'rxjs';
import { Ticket } from 'src/app/models/Ticket';
import { TicketServiceService } from 'src/app/services/TicketService/ticket-service.service';
@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css']
})
export class AddEditComponent implements OnInit {
  ticket:Ticket={
    ticketID :this.local.get('ticketID'),
    userID:this.local.get('currentUser').userID,
    claimID:0,
    policyID:0,
    details:''
  }
  constructor(private local:LocalStorageService, private tService:TicketServiceService, private router:Router) { }
  updateTicket():Observable<Ticket>{
    if(document.getElementById('details')){
      this.ticket.details = document.getElementById('details')?.ariaValueMax as string;
    }
    this.ticket.claimID = document.getElementById('claimID')?.ATTRIBUTE_NODE as number;
    this.ticket.policyID = document.getElementById('policyID')?.ATTRIBUTE_NODE as number;
    this.router.navigateByUrl('/ticket')
    return this.tService.updateTick(this.ticket);
  }
  ngOnInit(): void {
  }

}
