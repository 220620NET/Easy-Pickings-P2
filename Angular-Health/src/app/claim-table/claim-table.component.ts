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

  displayedColumns:string[]=['claimID', 'patientID', 'doctorID', 'policyID','reasonForVisit','status', 'demo-update', 'demo-delete'];
  claims:Claim[] =[{
    claimID:0,
    userID:0,
    policyID:0,
    doctorID:0,
    status:'here',
    reasonForVisit:'here'
  }] 
 // router: any;
  constructor(private http:HttpClient,private local: LocalStorageService, private auth:AuthServiceService,private claim:ClaimServiceService, private router:Router) { }
   

    getClaimsByID():void{
      this.claim.getClaimsByID(this.local.get('currentUser').userID).subscribe((res)=>{
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
              this.getClaimsByID()
            })
          }
      

  ngOnInit(): void {
 
    this.getClaimsByID();
  }


}
