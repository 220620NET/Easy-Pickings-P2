import { Component, Input, OnInit } from '@angular/core';
import { DiscussionService } from 'src/app/services/discussion.service';
@Component({
  selector: 'app-add-edit-discussion',
  templateUrl: './add-edit-discussion.component.html',
  styleUrls: ['./add-edit-discussion.component.css']
})
export class AddEditDiscussionComponent implements OnInit {


  constructor(private service:DiscussionService) {}
  @Input() disc: any;
  discussionID!: string;
  userID!: string;
  body!: string;
  dateCreated!: string;


  ngOnInit(): void {
    this.discussionID=this.disc.discussionID;
    this.body=this.disc.body;
    this.userID=this.disc.userID;
    this.dateCreated=this.disc.dateCreated;
  }

  createDiscussion(){
    let val = {discussionID: this.discussionID,
              body: this.body,
              userID: this.userID,
              dateCreated: this.dateCreated};
        this.service.createDiscussion(val).subscribe(res=>{
              alert(res.toString())
               });

  }
  updateDiscussion(){
    let val = {discussionID: this.discussionID,
               body: this.body,
               userID: this.userID,
               dateCreated: this.dateCreated};
          this.service.updateDiscussion(val).subscribe(res=>{
                alert(res.toString())
               });
    }
}
