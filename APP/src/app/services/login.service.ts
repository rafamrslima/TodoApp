import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  apiUrl: string = 'https://localhost:7084/user/login';

  sendLoginRequest(email:string, password: string){
    return this.http.post<any>(this.apiUrl, {email: email, password: password}, {observe: 'response'}); 
  }
}
