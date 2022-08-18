import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LocalStorageService } from 'angular-web-storage';
import { User } from 'src/app/models/User';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  constructor(private http:HttpClient, private local:LocalStorageService, private router:Router) { }
  username : FormControl = new FormControl('', [Validators.required]);
  password : FormControl = new FormControl('', [Validators.required]); 
  firstName : FormControl = new FormControl('', [Validators.required]); 
  lastName : FormControl = new FormControl('', [Validators.required]); 
  middleInitial : FormControl = new FormControl('', [ Validators.required]); 
  DoB : FormControl = new FormControl('', [ Validators.required]); 
  submit():void{
    let user:User=this.local.get('currentUser')
    if(this.firstName.value){user.first_name=this.firstName.value;}
    if(this.middleInitial.value){user.middle_init=this.middleInitial.value}
    if(this.lastName.value){user.last_name=this.lastName.value}
    if(this.DoB.value){user.DoB=this.DoB.value}
    if(this.username.value){user.username=this.username.value}
    if(this.password.value){user.password=this.password.value}
    this.http.put('https://easy-pickings-p2.azurewebsites.net/reset',user).subscribe((res)=>{
      this.local.set('currentUser', user);  
      this.router.navigateByUrl('/profile')
    })
  }
  ngOnInit(): void {
  }

}
