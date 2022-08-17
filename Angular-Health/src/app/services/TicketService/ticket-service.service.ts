import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from 'src/app/models/Ticket';
import { Observable } from 'rxjs';
import { TicketToAdd } from 'src/app/models/TicketToAdd';

@Injectable({
  providedIn: 'root'
})
export class TicketServiceService {
  api:string = 'https://easy-pickings-p2.azurewebsites.net/';
  constructor(private http:HttpClient) { }
  getTicketsByID(patient:number):Observable<Ticket[]>{
    return this.http.get(this.api+`ticket/patient/${patient}`) as Observable<Ticket[]>
  }
  updateTick(tick:Ticket):Observable<Ticket>{
    return this.http.put(this.api+`update/ticket`,tick) as Observable<Ticket>
  }
  addTick(tick:TicketToAdd):Observable<TicketToAdd>{
    return this.http.post(this.api+`submit/ticket`,tick) as Observable<TicketToAdd>
  }
  deleteTick(t:number):Observable<Ticket>{
    return this.http.delete(this.api+`delete/ticket?ID=${t}`) as Observable<Ticket>
  }
}
