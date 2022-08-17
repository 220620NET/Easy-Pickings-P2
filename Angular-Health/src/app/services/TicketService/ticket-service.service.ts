import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from 'src/app/models/Ticket';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketServiceService {
  api:string = 'https://easy-pickings-p2.azurewebsites.net/ticket';
  constructor(private http:HttpClient) { }
  getTicketsByID(ticketID:number):Observable<Ticket[]>{
    return this.http.get(this.api+`/patient/${ticketID}`) as Observable<Ticket[]>
  }
}
