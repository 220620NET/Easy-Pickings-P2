import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { LocalStorageService } from 'angular-web-storage';
import { ClaimToAdd } from 'src/app/models/ClaimToAdd';
import { User } from 'src/app/models/User';
import { ClaimServiceService } from 'src/app/services/ClaimService/claim-service.service';
import { Claim } from 'src/app/models/Claim';

import { FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-add-edit-claim',
  templateUrl: './add-edit-claim.component.html',
  styleUrls: ['./add-edit-claim.component.css']
})
export class AddEditClaimComponent implements OnInit {
  
  states=[{name:"Pending", restrict:'Patient'},{name:"Approved by Doctor; Pending on Insurance", restrict:'Doctor'},{name:"Denied by Doctor needs more info", restrict:'Doctor'},{name: "Approved by Doctor; Approved by Insurance", restrict:'Insurance'}, {name:'Denied by Insurance contact for assistance', restrict:'Insurance'}]; 
  constructor(private local:LocalStorageService, private service:ClaimServiceService, private router:Router) { }
  user():string{
    return this.local.get('currentUser').role;
  }

  doctorID:FormControl =new FormControl()
  policyID:FormControl =new FormControl()
  reasonForVisit:FormControl =new FormControl()
  state:string='Pending'
  switchState(a:string):void{
    this.state = a;
  }
  
  addClaim():void{ 
    let c:ClaimToAdd={
      userID: this.local.get('currentUser').userID,
      doctorID: this.doctorID.value,
      policyID: this.policyID.value,
      reasonForVisit: this.reasonForVisit.value,
      status: this.state
    }
    this.service.addClaim(c).subscribe((res)=>{
      console.log(res);
      this.router.navigateByUrl('/main')
    }
    )
  }
  updateClaim():void{ 
    let c:Claim={
      claimID: this.local.get('claimID'),
      userID: this.local.get('currentUser').userID,
      doctorID: this.doctorID.value,
      policyID: this.policyID.value,
      reasonForVisit: this.reasonForVisit.value,
      status: this.state
    }
    this.service.updateClaim(c).subscribe((res)=>{
      console.log(res);
      this.router.navigateByUrl('/main')
    }
    )
  }
  ngOnInit(): void {
    console.log(this.states)
  }

}
