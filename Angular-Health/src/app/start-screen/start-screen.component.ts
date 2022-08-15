import { Component, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { FormControl, Validators } from '@angular/forms';
import { UserLogin } from '../models/UserLogin';
import { Injectable } from '@angular/core';
import { User } from '../models/User';
import { Observable } from 'rxjs';
import { AuthServiceService } from '../services/AuthService/auth-service.service';
import { UserRegister } from '../models/UserRegister';
import { Router } from '@angular/router';
@Component({
  selector: 'app-start-screen',
  templateUrl: './start-screen.component.html',
  styleUrls: ['./start-screen.component.css']
})
export class StartScreenComponent implements OnInit {

  constructor(private http:HttpClient, private auth:AuthServiceService, private router:Router) { }

  api: string = 'https://easy-pickings-p2.azurewebsites.net/';
  username : FormControl = new FormControl('', [
    Validators.required
  ]);
  password : FormControl = new FormControl('', [
    Validators.required
  ]); 
  firstName : FormControl = new FormControl('', [
    Validators.required
  ]); 
  lastName : FormControl = new FormControl('', [
    Validators.required
  ]); 
  middleInitial : FormControl = new FormControl('', [
    Validators.required
  ]); 
  DoB : FormControl = new FormControl('', [
    Validators.required
  ]); 
  role : FormControl = new FormControl('', [
    Validators.required
  ]); 
  
  mode:string='login';
  modes:any={
    login:'login',
    register:'register'
  }
  login() : void{
    this.username.markAsTouched();
    this.password.markAsTouched();
    let user : UserLogin = {username:this.username.value,password:this.password.value};
    console.log(user);
    this.http.post(this.api + `login`,user).subscribe((res)=>{
      console.log(res);
      this.auth.setCurrentUser(res as User);
      this.router.navigateByUrl('/main');
    }
    )
  }
  register():void{
    let user:UserRegister ={
      firstName: this.firstName.value,
      middleInitial: this.middleInitial.value,
      lastName: this.lastName.value,
      username: this.username.value,
      password: this.password.value,
      DoB: this.DoB.value,
      role: this.role.value
    };
    this.http.post(this.api+'register',user).subscribe((res)=>{
      console.log(res);
      this.auth.setCurrentUser(res as User);
      this.router.navigateByUrl('/main')
    })
  }
  switchMode(mode:string):void{
    this.mode=mode;
    this.username.reset();
    this.password.reset();
  }
  ngOnInit(): void {
  }

}
