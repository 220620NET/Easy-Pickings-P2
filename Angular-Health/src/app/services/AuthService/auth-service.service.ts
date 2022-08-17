import { Injectable } from '@angular/core';
import {LocalStorageService} from 'angular-web-storage';
import { User } from 'src/app/models/User';
@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  constructor(private local:LocalStorageService) { }
  public setCurrentUser(user:User){
    if(user){
      this.local.set('currentUser', user);
    }
  }
  public getCurrentUser():User{
    return this.local.get('currentUser');
  }
  public isAuthenticated(){
    if(this.local.get('currentUser')) return true;
    return false;
  }
}
