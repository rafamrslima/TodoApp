import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry } from 'rxjs';
import { ITodo } from '../interfaces/todo';

@Injectable({
  providedIn: 'root'
})
export class ToDoService {

  constructor(private http: HttpClient) { }

  apiUrl: string = 'https://localhost:7084/todo';

  createTodoRequest(userId:string, title: string, deadline: Date) : Observable<any> {
    var headers = new HttpHeaders().set('Authorization', this.retrieveToken());
    var body = { 
      ownerId: userId, 
      title: title,
      ...(deadline && { deadline : deadline })
    }; 
 
    return this.http.post<any>(this.apiUrl + '/create', body, {'headers': headers} ); 
  } 

  getTodoList(userId: string): Observable<ITodo> {
    
    var headers = new HttpHeaders().set('Authorization', this.retrieveToken());
    return this.http.get<ITodo>(this.apiUrl + '?userId=' + userId, {'headers': headers}).pipe(retry(1));
  }

  changeItemStatus(itemId: string, isComplete:boolean) : Observable<any> {
    var headers = new HttpHeaders().set('Authorization', this.retrieveToken()); 
    var body = { isComplete: isComplete  };
    return this.http.put<any>(this.apiUrl + '/' + itemId, body, {'headers': headers}); 
  }

  retrieveToken() {
    return 'bearer ' + localStorage.getItem('token')??''; 
  } 

  processError(err: any){
    console.log('error')
  }
}
