import { HttpClient } from '@angular/common/http';
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

  ModalTitle: string | undefined; //this is for my modal add/edit/delete buttons
  ActivateAddEditDiscComp:boolean=false;
  disc:any;

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
  deleteClick(item: { discussionID: any; }){
    if(confirm('Are you sure you want to delete this post?')){
      this.service.deleteDiscussion(item.discussionID).subscribe((res)=>{this.refreshDiscussionList});

    }
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