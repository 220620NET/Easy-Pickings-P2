import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LocalStorageService } from 'angular-web-storage';
import { User } from '../models/User';
import { AuthServiceService } from '../services/AuthService/auth-service.service';
import { Policy } from '../models/Policy';
import { PolicyServiceService } from '../services/PolicyService/policy-service.service';
import { _MatDialogContainerBase } from '@angular/material/dialog';
import {MatTableModule} from '@angular/material/table';
import { Router } from '@angular/router';
@Component({
  selector: 'app-policy-table',
  templateUrl: './policy-table.component.html',
  styleUrls: ['./policy-table.component.css']
})
export class PolicyTableComponent implements OnInit {
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
  displayedColumns:string[]=['policyID', 'userID', 'coverage',  'demo-update', 'demo-delete'];
  policies:Policy[] =[{
    policyID :0, 
    insurance:0,
    coverage:'here'
  }]
  constructor(private http:HttpClient,private local:LocalStorageService, private auth:AuthServiceService, private tick:PolicyServiceService, private router:Router) { }
  getPolicy():void{
    this.tick.getPolicyByID(this.currentUser.userID).subscribe((res)=>{
      console.log(res);
      this.policies=res;
    })
    }
    updatePolicy(tick:Policy):void{
      if(this.local.get('currentUser').role === 'Insurance'){
        this.local.set('policy',tick.policyID);
        this.router.navigateByUrl('/update/policy');
      }else{
        alert('Not Allowed')
      }
    }
    deletePolicy(tick:Policy):void{
      if(this.local.get('currentUser').role === 'Insurance'){
        console.log(tick.policyID);
        this.tick.deleteTick(tick.policyID).subscribe((res)=>{
          console.log(res)
        })
        this.getPolicy()
      }
    }
    routeHandler(a:string):void{
      this.router.navigateByUrl(`/${a}`)
    }
    logout():void{
      this.local.clear();
    }
  ngOnInit(): void {
    this.currentUser = this.auth.getCurrentUser();
    this.getPolicy();
  }

}
