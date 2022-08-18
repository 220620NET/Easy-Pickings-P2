import { Component, OnInit } from '@angular/core'; 
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import { DiscussionService } from '../services/discussion.service';

import { Router,RouterLink } from '@angular/router';
import { LocalStorageService } from 'angular-web-storage';
import { AuthServiceService } from '../services/AuthService/auth-service.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private router:Router, private local:LocalStorageService, private auth:AuthServiceService) { }
  routeHandler(a:string):void{
    this.router.navigateByUrl(`/${a}`)
  }
  logout():void{
    this.local.clear();
    if(this.auth.isAuthenticated()===false){
      this.routeHandler('login')
    }
  }
  ngOnInit(): void {
    
  }

}