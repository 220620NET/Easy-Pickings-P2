import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService } from 'angular-web-storage';
import { Observable } from 'rxjs';
import { Policy } from 'src/app/models/Policy';
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
  constructor(private local:LocalStorageService, private tService:PolicyServiceService, private router:Router) { }
  updatePolicy():Observable<Policy>{
    if(document.getElementById('details')){
      this.policy.coverage = document.getElementById('details')?.ariaValueMax as string;
    } 
    this.router.navigateByUrl('/policy')
    return this.tService.updateTick(this.policy);
  }
  ngOnInit(): void {
  }

}
