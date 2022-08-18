import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { DiscussionService } from 'src/app/services/discussion.service';

@Component({
  selector: 'app-show-comments',
  templateUrl: './show-comments.component.html',
  styleUrls: ['./show-comments.component.css']
})
export class ShowCommentsComponent implements OnInit {
  constructor(private service: DiscussionService) { }
  @Input() disc: any;
  CommentList: any=[];

  ModalTitle: string | undefined; //this is for my modal add/edit/delete buttons
  ActivateAddEditComComp:boolean=false;
  com:any;

  ngOnInit(): void {
    this.refreshCommentList()
  }
  replyClick(){
    this.com={
      commentID: 0,
      userID: 0,
      messageID: 0,
      body: ""
    }
    this.ModalTitle="Create Comment";
    // this.ActivateAddEditComComp=true;
  }
  editClick(item: any){
    this.com=item;
    this.ModalTitle="Update Comment"
    // this.ActivateAddEditComComp=true;
  }
  deleteClick(item: any){
    if(confirm('Are you sure you want to delete this comment?')){
      this.service.deleteComment(item.commentID).subscribe(data=>{
        alert(data.toString());
        this.refreshCommentList();
      })
    }
  }
  closeClick(){
    this.ActivateAddEditComComp=false;
    this.refreshCommentList();
  }
  refreshCommentList(){
    this.service.getComment().subscribe(data=>{
      this.CommentList=data;
    });
  }


}
