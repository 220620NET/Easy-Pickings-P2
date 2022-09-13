import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DiscussionService {

  readonly APIUrl="https://easy-pickings-p2.azurewebsites.net"

  constructor(private http:HttpClient) { }

  createDiscussion(val:any){
    return this.http.post<any>(this.APIUrl+'/submit/discussion',val)
  }
  updateDiscussion(val:any){
    return this.http.put<any>(this.APIUrl+'/update/discussion',val)
  }
  deleteDiscussion(val:any){
    return this.http.delete<any>(this.APIUrl+'/delete/discussion?discussionID='+val)
  }
  getAllDiscussions():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/discussion')

  }
//comment api

  createComment(val:any){
    return this.http.post<any>(this.APIUrl+'/submit/comment',val)
  }
  updateComment(val:any){
    return this.http.put<any>(this.APIUrl+'/update/comment',val)
  }
  deleteComment(val:any){
    return this.http.delete<any>(this.APIUrl+'/delete/comment?commentID='+val)
  }
  getComment():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/comment')

  }
}