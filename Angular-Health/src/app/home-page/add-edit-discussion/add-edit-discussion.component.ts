import { Component, Input, OnInit } from '@angular/core';
import { DiscussionService } from 'src/app/discussion.service';

@Component({
  selector: 'app-add-edit-discussion',
  templateUrl: './add-edit-discussion.component.html',
  styleUrls: ['./add-edit-discussion.component.css']
})
export class AddEditDiscussionComponent implements OnInit {

  constructor(private service:DiscussionService) {}
  @Input() discussion: any;
  DiscussionID!: string;
  DiscussionBody!: string;

  ngOnInit(): void {
    this.DiscussionID=this.discussion.DiscussionID;
    this.DiscussionBody=this.discussion.DiscussionBody;
  }

  createDiscussion(){
    let val = {DiscussionID: this.DiscussionID,
          DiscussionBody: this.DiscussionBody};
          this.service.createDiscussion(val).subscribe(res=>{
                alert(res.toString())
               });

  }
  updateDiscussion(){
    let val = {DiscussionID: this.DiscussionID,
          DiscussionBody: this.DiscussionBody};
          this.service.createDiscussion(val).subscribe(res=>{
                alert(res.toString())
               });
    }
}
