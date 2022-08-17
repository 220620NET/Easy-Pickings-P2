import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService } from 'angular-web-storage'; 
import { Ticket } from 'src/app/models/Ticket';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TicketServiceService } from 'src/app/services/TicketService/ticket-service.service'; 
import { TicketToAdd } from 'src/app/models/TicketToAdd';
@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css']
})
export class AddEditComponent implements OnInit {
  constructor(private local:LocalStorageService, private tService:TicketServiceService, private router:Router ) { }
  claimID:FormControl=new FormControl('', [
    Validators.required
  ]);
  policyID: FormControl = new FormControl('', [
    Validators.required
  ]);
  details:FormControl=new FormControl('', [
    Validators.required
  ]);
  updateTicket():void{  
    let ticket:Ticket={
      ticketID :this.local.get('ticketID'),
      userID:this.local.get('currentUser').userID,
      claimID:this.claimID.value,
      policyID:this.policyID.value,
      details:this.details.value
    };
    this.tService.updateTick(ticket).subscribe((res)=>{
      ticket = res;
      console.log(ticket);
      this.router.navigateByUrl('/ticket')
    })
  }
  addTicket():void{  
    let ticket:TicketToAdd={ 
      userID:this.local.get('currentUser').userID,
      claimID:this.claimID.value,
      policyID:this.policyID.value,
      details:this.details.value
    };
    
    this.tService.addTick(ticket).subscribe((res)=>{
      ticket = res;
      console.log(ticket);
      this.router.navigateByUrl('/ticket')
    })
  }
  ngOnInit(): void {
  }

}
