import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IUser } from '../interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class CreateUserService {

  constructor(private http: HttpClient) { }

  apiUrl: string = 'https://localhost:7084/user/create';

  sendCreateUserRequest(userData: IUser) {
    return this.http.post<any>(this.apiUrl, userData, {observe: 'response'}); 
  }
}
