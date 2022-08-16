import { Component, OnInit } from '@angular/core'; 
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import { Router,RouterLink } from '@angular/router';
@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private router:Router) { }
  routeHandler(a:string):void{
    this.router.navigateByUrl('/ticket')
  }
  ngOnInit(): void {
  }

}
