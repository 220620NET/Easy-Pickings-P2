import { Component, OnInit } from '@angular/core'; 
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import { DiscussionService } from 'src/app/discussion.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private service: DiscussionService) { }
  DiscussionList:any=[];

  ngOnInit(): void {
    this.refreshDiscussionList
  }
  refreshDiscussionList(){
    this.service.getAllDiscussions().subscribe(data=>{
      this.DiscussionList=data;
    });
  }

}
