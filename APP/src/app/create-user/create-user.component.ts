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
      () => {
        this.resultMessage = "User registered successfully."; 
        this.showAlert = true;
        this.classMessageAlert = 'alert alert-success'
         
      },
        (error) => { 
        let errorMessage: string | null = null;
        if(error.error.errors){
          const errorKeys = Object.keys(error.error.errors);
          errorMessage = '';

          for (const key of errorKeys) {
            errorMessage += error.error.errors[key].join(' ');
          }
        }
        this.resultMessage = errorMessage?? "System is temporary unavailable, sorry for the incovinience."
        this.showAlert = true;
        this.classMessageAlert = 'alert alert-danger'
      });  
  }
}
