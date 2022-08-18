import { Component, OnInit } from '@angular/core';
import { Claim } from '../models/Claim';
import { AuthServiceService } from '../services/AuthService/auth-service.service';
import { User }from '../models/User';
import { HttpClient } from '@angular/common/http';
import { LocalStorageService } from 'angular-web-storage';
import { Observable } from 'rxjs';
import { Router, RouteReuseStrategy } from '@angular/router';
import { ClaimServiceService } from '../services/ClaimService/claim-service.service';

@Component({
  selector: 'app-claim-table',
  templateUrl: './claim-table.component.html',
  styleUrls: ['./claim-table.component.css']
})
export class ClaimTableComponent implements OnInit {
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

//claims:any=[]
  displayedColumns:string[]=['demo-id', 'demo-claim', 'demo-policy', 'demo-update', 'demo-delete'];
  claims:Claim[] =[{
    claimID:0,
    claimPatientID:0,
    claimPolicyID:0,
    claimStatus:'here',
    
  }]
  router: any;
 // router: any;
  constructor(private http:HttpClient,private local: LocalStorageService, private auth:AuthServiceService,private claim:ClaimServiceService, router:Router) { }
   

    getClaimsByID():void{
      this.claim.getClaimsByID(this.currentUser.userID).subscribe((res)=>{
        console.log(res);
        this.claims=res;
      })
      }

    updateClaim(claim:Claim):void{
      this.local.set('claimID',claim.claimID);
      this.router.navigateByUrl('/update/claim');
    }

  //  addClaim(claim:Claim)

    routeHandler(a:string):void{
    this.router.navigateByUrl(`/${a}`)
    }
    logout():void{
      this.local.clear();
    }

    deleteClaim(claim:Claim):void{
            console.log(claim.claimID);
            this.claim.deleteClaim(claim).subscribe((res: any)=>{
              console.log(res)
            })
            this.getClaimsByID()
          }
      

  ngOnInit(): void {

    this.currentUser = this.auth.getCurrentUser();
    this.getClaimsByID();
  }

}




