import { Component } from '@angular/core';
import { ToDoService } from '../services/todo.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent {

  constructor(private service: ToDoService) { 
      this.getTodoList();
      this.userId = localStorage.getItem('userId') ?? '';
  }

  showAlert = false;
  classMessageAlert = '';
  resultMessage = ''

  todoList: any = [];
  userId = '';

   getTodoList() {
    var userId = localStorage.getItem('userId');
    if(userId === null)
      return; //error
   
     this.service.getTodoList(userId).subscribe((res: {}) => {
      this.todoList = res;
    });
   }

   saveItem(form: any){ 
    var content = form.value;
    this.service.createTodoRequest(this.userId, content.title, content.deadline).subscribe(data => { 
      this.getTodoList();
      this.resultMessage = 'Item added successfully';
      this.showSuccessAlert();
      form.reset();
    },
    (error) => {
      this.showError(error);
     }
    )
   }

   changeItemStatus(itemId: string, event: any) {
    this.service.changeItemStatus(itemId, event.target.checked).subscribe(data => { 
      this.getTodoList();
      this.resultMessage = 'Item updated successfully';
      this.showSuccessAlert();
    },
    (error) => {
      this.showError(error);
     }
    )
   }

   showSuccessAlert(){
    this.classMessageAlert = 'alert alert-success'
    this.showAlert = true;
   }

   showError(error: any){
    this.resultMessage = error.error.error?? "System is temporary unavailable, sorry for the incovinience."
    this.showAlert = true;
    this.classMessageAlert = 'alert alert-danger'
   }
}