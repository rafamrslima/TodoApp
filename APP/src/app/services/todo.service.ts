import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToDoService {

  constructor(private http: HttpClient) { }

  apiUrl: string = 'https://localhost:7084/todo/create';

  sendCreateTodoRequest(userId:number, title: string, deadline: Date) {
    return this.http.post<any>(this.apiUrl, {userId: userId, title: title, deadline: deadline}, {observe: 'response'}); 
  }

  GetTodoList(userId: number) {
    return this.http.post<any>(this.apiUrl, {userId: userId}, {observe: 'response'}); 
  }
}
