import { Component } from '@angular/core';
import { ITodo } from '../interfaces/todo';
import { ToDoService } from '../services/todo.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent {

  constructor(private service: ToDoService) {
    this.todoList = [ 
      { id: 1, title: 'Shopping', 
        creationDate: new Date(2023, 6, 21), 
        deadline: new Date(2023, 6, 25), 
        done: false 
      }]
  }

  todoList: ITodo[] = [];

   getTodoList() {
    this.service.GetTodoList(1).subscribe(data => {
      //this.todoList.push(data);
      console.log(data);
    },
    error => {}
    )
   }

   saveItem(content: any){
    console.log(content);
    this.service.sendCreateTodoRequest(1, content.title, content.deadline).subscribe(data => {
      console.log(data);
    },
    error => {}
    )
   }
}

