import { Component, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { FormControl, Validators } from '@angular/forms';

import { Injectable } from '@angular/core';
import { User } from '../models/User';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-start-screen',
  templateUrl: './start-screen.component.html',
  styleUrls: ['./start-screen.component.css']
})
export class StartScreenComponent implements OnInit {

  constructor(private http:HttpClient) { }

  api: string = 'https://easy-pickings-p2.azurewebsites.net/';
  username : FormControl = new FormControl('', [
    Validators.required
  ]);
  password : FormControl = new FormControl('', [
    Validators.required
  ]); 
  login() : void{
    this.username.markAsTouched();
    this.password.markAsTouched();
    let user : User = {username:this.username.value,password:this.password.value,firstName:'',lastName:'',middleInitial:'', DoB:'',role:'',userID:0};
    console.log(user);
    this.http.post(this.api + `login`,user).subscribe((res)=>
    console.log(res))
  }
  ngOnInit(): void {
  }

}
