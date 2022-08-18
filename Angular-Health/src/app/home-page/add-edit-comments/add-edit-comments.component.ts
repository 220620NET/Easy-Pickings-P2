import { Component, Input, OnInit } from '@angular/core';
import { DiscussionService } from 'src/app/services/discussion.service';

@Component({
  selector: 'app-add-edit-comments',
  templateUrl: './add-edit-comments.component.html',
  styleUrls: ['./add-edit-comments.component.css']
})
export class AddEditCommentsComponent implements OnInit {

  constructor(private service:DiscussionService) { }

  @Input() com: any;
  commentID!: string;
  userID!: string;
  messageID!: string;
  body!: string;


  ngOnInit(): void {
    this.commentID=this.com.commentID;
    this.userID=this.com.userID;
    this.messageID=this.com.messageID;
    this.body=this.com.body;
  }

  createComment(){
    let val = {commentID: this.commentID,
               userID: this.userID,
               messageID: this.messageID,
               body: this.body};
              this.service.createComment(val).subscribe(res=>{
                alert(res.toString())
              });
  }
  updateComment(){
      let val = {commentID: this.commentID,
                 userID: this.userID,
                 messageID: this.messageID,
                body: this.body};
     this.service.updateComment(val).subscribe(res=>{
       alert(res.toString())
     });
  }

}