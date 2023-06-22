import { Component } from '@angular/core';
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

  saveUser(form: any) {
    this.service.createUserRequest(form.value).subscribe(
      () => {
        this.resultMessage = "User registered successfully."; 
        this.showAlertWithTimeout();
        this.classMessageAlert = 'alert alert-success'
        form.reset();
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
        this.showAlertWithTimeout();
        this.classMessageAlert = 'alert alert-danger'
      });  
  }

  showAlertWithTimeout() {
    this.showAlert = true;
        setTimeout(() => {
          this.showAlert = false;
        }, 3000);
  }
}
