import { Component, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserLogin } from '../models/UserLogin';
import { Injectable } from '@angular/core';
import { User } from '../models/User';
import { Observable } from 'rxjs';
import { AuthServiceService } from '../services/AuthService/auth-service.service';
import { UserRegister } from '../models/UserRegister';
import { Router, RouterLink } from '@angular/router';
import { FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-start-screen',
  templateUrl: './start-screen.component.html',
  styleUrls: ['./start-screen.component.css']
})
export class StartScreenComponent implements OnInit {
  roleForm : FormGroup=new FormGroup('',[]);
  roles=[{
    name:"Patient"
  },{name:"Doctor"},{name:"Employee"},{name: "Insurance Company"}];
  constructor(private http:HttpClient, private auth:AuthServiceService, private router:Router, private fb:FormBuilder) { }

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
  };
  register():void{
    
    let user:UserRegister ={
      first_name: this.firstName.value,
      middle_init: this.middleInitial.value,
      last_name: this.lastName.value,
      username: this.username.value,
      password: this.password.value,
      doB: this.DoB.value,
      role: this.roleForm.value
    };
    console.log(user);
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
    this.roleForm=this.fb.group({role:[null]});
  }

}
