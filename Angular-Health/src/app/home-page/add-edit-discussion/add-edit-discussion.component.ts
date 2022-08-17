import { Component, OnInit } from '@angular/core';
import { DiscussionService } from 'src/app/discussion.service';

@Component({
  selector: 'app-add-edit-discussion',
  templateUrl: './add-edit-discussion.component.html',
  styleUrls: ['./add-edit-discussion.component.css']
})
export class AddEditDiscussionComponent implements OnInit {

  constructor(private service:DiscussionService) {

  
   }

  ngOnInit(): void {

  }

}
