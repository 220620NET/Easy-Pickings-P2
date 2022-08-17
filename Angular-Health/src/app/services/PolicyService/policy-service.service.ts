import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Policy } from 'src/app/models/Policy';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PolicyServiceService {
  api:string = 'https://easy-pickings-p2.azurewebsites.net/';
  constructor(private http:HttpClient) { }
  getPolicyByID(policyID:number):Observable<Policy[]>{
    return this.http.get(this.api+`/patient/${policyID}`) as Observable<Policy[]>
  }
}