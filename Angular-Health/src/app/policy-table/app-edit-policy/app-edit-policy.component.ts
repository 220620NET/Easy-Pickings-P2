import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { LocalStorageService } from 'angular-web-storage';
import { Observable } from 'rxjs';
import { Policy } from 'src/app/models/Policy';
import { PolicyToAdd } from 'src/app/models/PolicyToAdd';
import { PolicyServiceService } from 'src/app/services/PolicyService/policy-service.service';
@Component({
  selector: 'app-app-edit-policy',
  templateUrl: './app-edit-policy.component.html',
  styleUrls: ['./app-edit-policy.component.css']
})
export class AppEditPolicyComponent implements OnInit {

  policy:Policy={
    policyID :this.local.get('policyID'),
    insurance:this.local.get('currentUser').userID, 
    coverage:''
  }
  details:FormControl=new FormControl()
  constructor(private local:LocalStorageService, private tService:PolicyServiceService, private router:Router) { }
  updatePolicy():void{
    if(this.details.value){
      this.policy.coverage = this.details.value;
      console.log(this.policy)
      this.tService.updateTick(this.policy).subscribe((res)=>{
        this.router.navigateByUrl('/policy') 
      })
    } else{
      alert('You need to explain the coverage!')
    } 
  }
  pta:PolicyToAdd={ 
    insurance: this.local.get('currentUser').userID,
    coverage: ''
  }
  addPolicy():void{
    if(this.details.value){
      this.pta.coverage = this.details.value;
      console.log(this.policy)
      this.tService.addTick(this.pta).subscribe((res)=>{
        this.router.navigateByUrl('/policy') 
      })
    } else{
      alert('You need to explain the coverage!')
    } 
  }
  ngOnInit(): void {
  }

}
