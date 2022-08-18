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

/*

app.MapGet("/discussion/id/{discussionID}", (int discussionID, DiscussionController controller) => controller.GetByID(discussionID));
app.MapGet("/discussion/userid/{userID}", (int userID, DiscussionController controller) => controller.GetByUserID(userID));

app.MapPost("/submit/comment", (Comment comment, CommentController controller) => controller.CreateComment(comment));
app.MapPut("/update/comment", (Comment comment, CommentController controller) => controller.UpdateComment(comment));
app.MapDelete("/delete/comment", (int commentID, CommentController controller) => controller.DeleteComment(commentID));
app.MapGet("/comment", (CommentController controller) => controller.GetAllComments());
app.MapGet("/comment/id/{commentID}", (int commentID, CommentController controller) => controller.GetCommentById(commentID));
app.MapGet("/comment/user/{userID}", (int userID, CommentController controller) => controller.GetCommentByUser(userID));
app.MapGet("/comment/discussion/{postID}", (int postID, CommentController controller) => controller.GetCommentByPost(postID));

*/  
}
