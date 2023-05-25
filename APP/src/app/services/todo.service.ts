import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry } from 'rxjs';
import { ITodo } from '../interfaces/todo';

@Injectable({
  providedIn: 'root'
})
export class ToDoService {

  constructor(private http: HttpClient) { }

  apiUrl: string = 'https://localhost:7084/todo';

  createTodoRequest(userId:string, title: string, deadline: Date) {
    var body = { 
      ownerId: userId, 
      title: title, 
      deadline: deadline 
    };
    return this.http.post<any>(this.apiUrl + '/create', body, {observe: 'response'}); 
  } 

  GetTodoList(userId: string): Observable<ITodo> {
    return this.http .get<ITodo>(this.apiUrl + '?userId=' + userId).pipe(retry(1));
  }

  processError(err: any){
    console.log('error')
  }
}
