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
  user:User ={
    userID:0,
    firstName:'',
    middleInitial:'',
    lastName:'',
    username: this.username.value,
    password : this.password.value,
    DoB: '',
    role:''
  };
  login() : void{
    this.http.post(this.api + `login`,this.user).subscribe((res)=>
    console.log(res))
  }
  ngOnInit(): void {
  }

}
