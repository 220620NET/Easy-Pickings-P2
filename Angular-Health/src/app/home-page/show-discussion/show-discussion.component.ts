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

  ModalTitle: string | undefined; //Who knows...
  ActivateAddEditDiscComp:boolean=false;
  disc:any;

  DiscussionIDFilter:string="";
  DiscussionBodyFilter:string="";
  DiscussionListWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshDiscussionList()
  }
  addClick(){
    this.disc={
      DiscussionID:0,
      DiscussionBody:""
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
      this.service.deleteDiscussion(item.DiscussionID).subscribe(data=>{
        alert(data.toString());
        this.refreshDiscussionList;
      })
    }
  }
  closeClick(){
    this.ActivateAddEditDiscComp=false;
    this.refreshDiscussionList();
  }

  refreshDiscussionList(){
    this.service.getAllDiscussions().subscribe(data=>{
      this.DiscussionList=data;
      this.DiscussionListWithoutFilter=data;
    });
  }
//probably don't need this. No clue what it does
      FilterFn(){
      let DiscussionIDFilter = this.DiscussionIDFilter;
      let DiscussionBodyFilter = this.DiscussionBodyFilter;

      this.DiscussionList = this.DiscussionListWithoutFilter.filter(function (el: any){
        return el.DiscussionID.toString()&&
        el.DiscussionBody.toString().includes(
          DiscussionBodyFilter.toString().trim()
        )
      });
    }
  }

