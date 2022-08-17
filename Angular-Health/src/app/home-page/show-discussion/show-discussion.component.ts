import { Component, OnInit } from '@angular/core';
import { DiscussionService } from 'src/app/discussion.service';

@Component({
  selector: 'app-show-discussion',
  templateUrl: './show-discussion.component.html',
  styleUrls: ['./show-discussion.component.css']
})
export class ShowDiscussionComponent implements OnInit {

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
