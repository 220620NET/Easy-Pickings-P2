import { Component, Input, OnInit } from '@angular/core';
import { DiscussionService } from 'src/app/discussion.service';

@Component({
  selector: 'app-add-edit-discussion',
  templateUrl: './add-edit-discussion.component.html',
  styleUrls: ['./add-edit-discussion.component.css']
})
export class AddEditDiscussionComponent implements OnInit {

  constructor(private service:DiscussionService) {}
  @Input() disc: any;
  DiscussionID!: string;
  UserID!: string;
  DiscussionBody!: string;
  DateCreated!: string;


  ngOnInit(): void {
    this.DiscussionID=this.disc.DiscussionID;
    this.DiscussionBody=this.disc.DiscussionBody;
    this.UserID=this.disc.UserID;
    this.DateCreated=this.disc.DateCreated;
  }

  createDiscussion(){
    let val = {DiscussionID: this.DiscussionID,
          DiscussionBody: this.DiscussionBody,
          UserID: this.UserID,
          DateCreated: this.DateCreated};
          this.service.createDiscussion(val).subscribe(res=>{
                alert(res.toString())
               });

  }
  updateDiscussion(){
    let val = {DiscussionID: this.DiscussionID,
          DiscussionBody: this.DiscussionBody,
          UserID: this.UserID,
          DateCreated: this.DateCreated};
          this.service.createDiscussion(val).subscribe(res=>{
                alert(res.toString())
               });
    }
}
