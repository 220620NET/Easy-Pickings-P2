import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService } from 'angular-web-storage';
import { Contact } from '../models/Contact';
import { User } from '../models/User';
import { ContactServiceService } from '../services/ContactService/contact-service.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  routeHandler(a:string):void{
    this.router.navigateByUrl(`/${a}`)
  }
  logout():void{
    this.local.clear();
  }
  api:string ='https://easy-pickings-p2.azurewebsites.net/';
  constructor(private local:LocalStorageService, private http:HttpClient, private router:Router, private contactFetch:ContactServiceService) { }
  contact:Contact={
    contactID: 0,
    pO_or_street: false,
    pO_number: 0,
    street_number: 0,
    street_name: '',
    city_state: '',
    zipcode: 0,
    userID: 0,
    phone: 0,
    email: ''
  }
  user:User =this.local.get('currentUser');
  getContact():void{
    this.contactFetch.getContact(this.local.get('currentUser').userID).subscribe((res)=>{
      this.contact=res;
    })
  }
  updateUser():void{
    this.local.set('update', 'user')
    this.router.navigateByUrl('/update/profile')
  }
  updateContact():void{
    this.local.set('contact', this.contact.contactID)
    this.local.set('isupdate', 'yes')
    this.router.navigateByUrl('/update/contact')
  }
  ngOnInit(): void {
    console.log(this.user)
    this.getContact()
  }

}
