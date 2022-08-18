import { HttpClient } from '@angular/common/http';
import { DiscussionService } from 'src/app/services/discussion.service';
import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from 'angular-web-storage';
@Component({
  selector: 'app-show-discussion',
  templateUrl: './show-discussion.component.html',
  styleUrls: ['./show-discussion.component.css']
})
export class ShowDiscussionComponent implements OnInit {

  constructor(private service: DiscussionService, private local:LocalStorageService) { }

  DiscussionList:any=[];
  CommentList: any=[];
  
  ModalTitle: string | undefined; //this is for my modal add/edit/delete buttons
  ActivateAddEditDiscComp:boolean=false;
  disc:any;
  ActivateAddEditComComp:boolean=false;
  com: any;
  ActivateShowComComp:boolean=false;
  showcom: any;

  ngOnInit(): void {
    this.refreshDiscussionList()
  }
  addClick(){             //this will be a model of what parameters need added, 
    this.disc={
      discussionID:0,
      userID: 0,
      discussionBody:"",
      dateCreated: ""
    }
    this.ModalTitle="Submit Discussion";
    this.ActivateAddEditDiscComp=true;
  }
  editClick(item: any){
    this.disc=item;
    this.ModalTitle="Update Discussion"
    this.ActivateAddEditDiscComp=true;
  }
  deleteClick(item: any){
    if(confirm('Are you sure you want to delete this post?')){
      this.service.deleteDiscussion(item.discussionID).subscribe(data=>{
        alert(data.toString());
        this.refreshDiscussionList();
      })
    }
  }

  replyClick(id:number){
    this.com={
      commentID: 0,
      userID: this.local.get('currentUser').userID,
      messageID: id,
      body: ""
    }
    this.ModalTitle="Create Comment";
    this.ActivateAddEditComComp=true;
  }
  viewClick(){
    this.ModalTitle="view comments"
    this.ActivateShowComComp=true;

  }
  closeClick(){
    this.ActivateAddEditDiscComp=false;
    this.refreshDiscussionList();
  }

  refreshDiscussionList(){
    this.service.getAllDiscussions().subscribe(data=>{
      this.DiscussionList=data;
    });
  }
}


