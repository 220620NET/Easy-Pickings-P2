import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from 'angular-web-storage';
import { AuthServiceService } from '../services/AuthService/auth-service.service';
import { Policy } from '../models/Policy';
import { User } from '../models/User';
@Component({
  selector: 'app-policy-table',
  templateUrl: './policy-table.component.html',
  styleUrls: ['./policy-table.component.css']
})
export class PolicyTableComponent implements OnInit {
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
  policy:any=[]
  constructor(private http:HttpClient,private local:LocalStorageService, private auth:AuthServiceService) { }
  getTickets():void{

  }
  
  ngOnInit(): void {
  }

}
