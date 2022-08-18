import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Policy } from 'src/app/models/Policy';
import { Observable } from 'rxjs';
import { PolicyToAdd } from 'src/app/models/PolicyToAdd';

@Injectable({
  providedIn: 'root'
})
export class PolicyServiceService {
  api:string = 'https://easy-pickings-p2.azurewebsites.net/';
  constructor(private http:HttpClient) { }
  getPolicyByID(policyID:number):Observable<Policy[]>{
    return this.http.get(this.api+`/patient/${policyID}`) as Observable<Policy[]>
  }
  updateTick(tick:Policy):Observable<Policy>{
    return this.http.put(this.api+`update/policy`,tick) as Observable<Policy>
  }
  addTick(tick:PolicyToAdd):Observable<PolicyToAdd>{
    return this.http.post(this.api+`submit/policy`,tick) as Observable<PolicyToAdd>
  }
  deleteTick(t:number):Observable<Policy>{
    return this.http.delete(this.api+`delete/policy?ID=${t}`) as Observable<Policy>
  }
}