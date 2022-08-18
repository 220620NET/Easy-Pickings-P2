import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from 'angular-web-storage';
import { ContactServiceService } from '../services/ContactService/contact-service.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private local:LocalStorageService, private contact:ContactServiceService) { }

  ngOnInit(): void {
  }

}
