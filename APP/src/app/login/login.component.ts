import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private service: LoginService, private router: Router) {
  }
 
  showAlert = false;
  resultMessage = '';
  classAlertMessage = '';

  login(data: any) {
    if (data.email == '' || data.password == '')
      return;

    this.service.sendLoginRequest(data.email, data.password).subscribe(
      data => {
        localStorage.setItem('userId', data.body.userId);
        localStorage.setItem('token', data.body.token);
        this.resultMessage = 'Login successfully works.';  
        this.showAlert = true;
        this.classAlertMessage = 'alert alert-success';
        this.router.navigate(['/todolist']);
      },
      error => {
        this.resultMessage = error.error.error ?? 'System is temporary unavailable, sorry for the incovinience.';
        this.showAlert = true;
        this.classAlertMessage = 'alert alert-danger'
      });
  }
}