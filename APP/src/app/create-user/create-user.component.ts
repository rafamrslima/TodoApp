import { Component } from '@angular/core';
import { IUser } from '../interfaces/user';
import { CreateUserService } from '../services/create-user.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent {
 
  constructor(private service: CreateUserService) { }

  showAlert = false;
  resultMessage = '';
  classMessageAlert = '';

  saveUser(data: IUser) {
    this.service.createUserRequest(data).subscribe(
      (result) => {
        this.resultMessage = "User registered successfully."; 
        this.showAlert = true;
        this.classMessageAlert = 'alert alert-success'
         
      },
        (error) => {
        this.resultMessage = error.error.error?? "System is temporary unavailable, sorry for the incovinience."
        this.showAlert = true;
        this.classMessageAlert = 'alert alert-danger'
      });  
  }
}
