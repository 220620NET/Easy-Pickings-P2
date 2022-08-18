import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Claim } from 'src/app/models/Claim';
import { Observable } from 'rxjs';
import {ClaimToAdd} from 'src/app/models/ClaimToAdd';

@Injectable({
  providedIn: 'root'
})
export class ClaimServiceService {
  api:string = 'https://easy-pickings-p2.azurewebsites.net/';
  constructor(private http:HttpClient) { }

  getClaimsByID(patient:number):Observable<Claim[]>{
    return this.http.get(this.api+`claim/patient/${patient}`) as Observable<Claim[]>
  }

    getClaimByID(patient:number):Observable<Claim>{
    return this.http.get(this.api+`claim/patient/${patient}`) as Observable<Claim>
  }

    updateClaim(claim:Claim):Observable<Claim>{
    return this.http.put(this.api+`update/claim`,claim) as Observable<Claim>
  }

    addClaim(claim:ClaimToAdd):Observable<ClaimToAdd>{
    return this.http.post(this.api+`submit/claim`,claim) as Observable<ClaimToAdd>
  }
     deleteClaim(claim:Claim):Observable<Claim>{
      return this.http.delete(this.api+`delete/claim?ID=${claim.claimID}`) as Observable<Claim>
     }

}
