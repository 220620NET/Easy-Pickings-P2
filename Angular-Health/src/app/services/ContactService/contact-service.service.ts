import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from 'src/app/models/Contact';
import { ContactToAdd } from 'src/app/models/ContactToAdd';

@Injectable({
  providedIn: 'root'
})
export class ContactServiceService {

  constructor(private http:HttpClient) {}
  getContacts():Observable<Contact[]>{
    return this.http.get('https://easy-pickings-p2.azurewebsites.net/contactinfo') as Observable<Contact[]>
  }
  getContact(user:number):Observable<Contact>{
    return this.http.get('https://easy-pickings-p2.azurewebsites.net/contact/user/'+user) as Observable<Contact>
  }
  addContact(contact:ContactToAdd):Observable<Contact>{
    return this.http.post('https://easy-pickings-p2.azurewebsites.net/submit/contact',contact) as Observable<Contact>
  }
  updateContact(contact:Contact):Observable<Contact>{
    return this.http.put('https://easy-pickings-p2.azurewebsites.net/update/contact',contact) as Observable<Contact>
  }
  deleteContact(contact:Contact):void{
    this.http.delete('https://easy-pickings-p2.azurewebsites.net/delete/contact?contactID='+contact.contactID);
  }
}
