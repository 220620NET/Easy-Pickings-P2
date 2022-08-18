import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Contact } from 'src/app/models/Contact';
import { Observable } from 'rxjs';
import { ContactToAdd } from 'src/app/models/ContactToAdd';

@Injectable({
  providedIn: 'root'
})
export class ContactServiceService {
  api:string = 'https://easy-pickings-p2.azurewebsites.net/';
  constructor(private http:HttpClient) { }
  getContactByID(contactID:number):Observable<Contact>{
    return this.http.get(this.api+`contact/ID/${contactID}`) as Observable<Contact>
  }
  updateContact(contact:Contact):Observable<Contact>{
    return this.http.put(this.api+`update/contact`,contact) as Observable<Contact>
  }
  addContact(contact:ContactToAdd):Observable<ContactToAdd>{
    return this.http.post(this.api+`submit/contact`,contact) as Observable<ContactToAdd>
  }
  deleteContact(contactID:number):Observable<Contact>{
    return this.http.delete(this.api+`delete/contact?ID=${contactID}`) as Observable<Contact>
  }
}