import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService } from 'angular-web-storage';
import { Observable } from 'rxjs';
import { Policy } from 'src/app/models/Policy';
import { PolicyServiceService } from 'src/app/services/PolicyService/policy-service.service';
@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css']
})
export class AddEditComponent implements OnInit {
  policy:Policy={
    policyID :this.local.get('policyID'),
    userID:this.local.get('currentUser').userID,
    insurance:0,
    coverage:0,
    details:''
  }
  constructor(private local:LocalStorageService, private tService:PolicyServiceService, private router:Router) { }
  updatePolicy():Observable<Policy>{
    if(document.getElementById('details')){
      this.policy.details = document.getElementById('details')?.ariaValueMax as string;
    }
    this.policy.userID = document.getElementById('userID')?.ATTRIBUTE_NODE as number;
    this.router.navigateByUrl('/policy')
    return this.tService.updateTick(this.policy);
  }
  ngOnInit(): void {
  }

}