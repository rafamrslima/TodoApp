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

  todoList: any = [];
  userId: string = '';

   getTodoList() {
    var userId = localStorage.getItem('userId');
    if(userId === null)
      return; //error
   
     this.service.GetTodoList(userId).subscribe((res: {}) => {
      this.todoList = res;
    });
   }

   saveItem(content: any){
    console.log(content);
    var userId = localStorage.getItem('userId'); 
    this.service.createTodoRequest(this.userId, content.title, content.deadline).subscribe(data => { 
      this.getTodoList();
    },
    function (error) { }
    )
   }
}

