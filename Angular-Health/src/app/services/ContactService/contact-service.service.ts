import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from 'src/app/models/Contact';

@Injectable({
  providedIn: 'root'
})
export class ContactServiceService {

  constructor(private http:HttpClient) { }
  getContacts():Observable<Contact[]>{
    return this.http.get('https://easy-pickings-p2.azurewebsites.net/contactinfo') as Observable<Contact[]>
  }
}
