import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocalStorage } from 'angular-web-storage';
import { Router } from '@angular/router';
import { LocalStorageService } from 'angular-web-storage'; 
import { Contact } from 'src/app/models/Contact';
import { ContactToAdd } from 'src/app/models/ContactToAdd';
import { ContactServiceService } from 'src/app/services/ContactService/contact-service.service';
import { Form, FormControl, RequiredValidator, Validators } from '@angular/forms';
@Component({
  selector: 'app-add-edit-contact',
  templateUrl: './add-edit-contact.component.html',
  styleUrls: ['./add-edit-contact.component.css']
})
export class AddEditContactComponent implements OnInit {

  constructor(private local:LocalStorageService, private service:ContactServiceService, private router:Router ) { }
  pO_or_street:FormControl = new FormControl('',[Validators.required])
  pO_number:FormControl= new FormControl()
  street_number:FormControl=new FormControl();
  street_name:FormControl=new FormControl()
  city_state:FormControl=new FormControl();
  zipcode:FormControl =new FormControl();
  phone:FormControl=new FormControl();
  email:FormControl=new FormControl();
  isPO():boolean{
    if(this.pO_or_street.value === 'yes'){
      return true
    }else{
      return false
    }
  }
  addContact():void{
    let contact:ContactToAdd={
      userID: this.local.get('currentUser').userID,
      pO_or_street: false,
      pO_number: 0,
      street_number: 0,
      street_name: 'N/A',
      city_state: this.city_state.value,
      zipcode: this.zipcode.value,
      phone: 0,
      email: ''
    }
    if((this.isPO())){
      contact.pO_number=this.pO_number.value;
    }else{
      contact.street_name = this.street_name.value;
      contact.street_number=this.street_number.value;
    }
    if(this.phone.value){
      contact.phone=this.phone.value;
    }
    if(this.email.value){
      contact.email =this.email.value;
    } 
    this.service.addContact(contact).subscribe((res)=>{
      console.log(res);
      this.router.navigateByUrl('/profile')
    })
  }
  update():boolean{
    if(this.local.get('isupdate')==='yes'){
      return true
    }
    return false
  }
  updateContact():void{
    let contact:Contact={
      contactID:this.local.get('contact'),
      userID: this.local.get('currentUser').userID,
      pO_or_street: false,
      pO_number: 0,
      street_number: 0,
      street_name: 'N/A',
      city_state: this.city_state.value,
      zipcode: this.zipcode.value,
      phone: 0,
      email: ''
    }
    if((this.isPO())){
      contact.pO_number=this.pO_number.value;
    }else{
      contact.street_name = this.street_name.value;
      contact.street_number=this.street_number.value;
    }
    if(this.phone.value){
      contact.phone=this.phone.value;
    }
    if(this.email.value){
      contact.email =this.email.value;
    } 
    this.service.updateContact(contact).subscribe((res)=>{
      console.log(res);
      this.router.navigateByUrl('/profile')
    })
  }
  ngOnInit(): void {
  }

}
