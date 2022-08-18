import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LocalStorageService } from 'angular-web-storage';
import { User } from '../models/User';
import { AuthServiceService } from '../services/AuthService/auth-service.service';
import { _MatDialogContainerBase } from '@angular/material/dialog'; 
import { Router, RouteReuseStrategy } from '@angular/router';
import { FormBuilder, FormControl } from '@angular/forms';
import { Contact } from '../models/Contact';
import { ContactServiceService } from '../services/ContactService/contact-service.service';

@Component({
  selector: 'app-contact-table',
  templateUrl: './contact-table.component.html',
  styleUrls: ['./contact-table.component.css']
})
export class ContactTableComponent implements OnInit {
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
  displayedColumns:string[]=['contactID' , 'PO_number', 'street_number', 'street_name','city_state', 'zipcode','userID', 'phone', 'email', 'demo-update', 'demo-delete'];
  contacts:Contact[]=[{
    contactID:0,
    userID:0,
    phone:0,
    email:'',
    PO_number:0,
    PO_or_street:true,
    street_name:'',
    street_number:0,
    city_state:'',
    zipcode:0
  }]
  getContacts():void{
    this.http.get(this.api+'contactinfo').subscribe((res)=>{
      this.contacts=res as Contact[];
    })
  }
  updateContact(contact:Contact):void{
    this.local.set('contactID',contact.contactID);
    this.router.navigateByUrl('/update/contact');
  }
  deleteContact(contact:Contact):void{
    console.log(contact.contactID);
    this.contact.deleteContact(contact.contactID).subscribe((res)=>{
      console.log(res)
    })
    this.getContacts()
  }
  routeHandler(a:string):void{
    this.router.navigateByUrl(`/${a}`)
  }
  logout():void{
    this.local.clear();
  }
  constructor(private http:HttpClient, private local:LocalStorageService, private auth:AuthServiceService, private contact:ContactServiceService, private router:Router) { }
  
  ngOnInit(): void {
    this.currentUser = this.auth.getCurrentUser();
    this.getContacts();
  }

}
