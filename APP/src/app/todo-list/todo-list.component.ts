import { Component, ViewChild } from '@angular/core';
import { ToDoService } from '../services/todo.service';
import { DateHelper } from '../helpers/date.helper';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent {

  constructor(private service: ToDoService, private dateHelper: DateHelper) { 
      this.getTodoList();
      this.userId = localStorage.getItem('userId') ?? '';
  }

  @ViewChild('addItemForm') addItemForm: NgForm | undefined;

  showAlert = false;
  isEdit = false;
  itemEditedId = ''
  classMessageAlert = '';
  resultMessage = '';
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
    if(this.isEdit){ 
      this.updateItem(form);
      return;
    } 
    this.createNewItem(form); 
   }

   createNewItem(form: any) {
    var content = form.value;
      this.service.createTodo(this.userId, content.title, content.deadline).subscribe(data => { 
        this.resultMessage = 'Item added successfully';
        this.showSuccessAlert();
        this.refreshPage(form);
      },
      (error) => {
        let errorMessage: string | null = null; 
        errorMessage = this.getErrorMessage(error, errorMessage);  
        this.showError(errorMessage); 
      })
   }

   updateItem(form: any){
    var content = form.value;
      this.service.editTodo(this.itemEditedId, content.title, content.deadline).subscribe(data => { 
        this.resultMessage = 'Item updated successfully';
        this.showSuccessAlert();
        this.refreshPage(form);
        this.isEdit = false;
      },
      (error) => { 
        let errorMessage: string | null = null; 
        errorMessage = this.getErrorMessage(error, errorMessage);  
        this.showError(errorMessage); 
      })
   }

   getErrorMessage(error: any, errorMessage: string | null) {
    if (error.error.errors) {
      errorMessage = '';
      const errorKeys = Object.keys(error.error.errors);

      for (const key of errorKeys) {
        errorMessage += error.error.errors[key].join(' ');
      }
    }
    else if (error.error.error) {
      errorMessage = error.error.error;
    }
    return errorMessage;
  }

   refreshPage(form: any){
    form.reset();
    this.getTodoList(); 
   }

   changeItemStatus(itemId: string, event: any) {
    this.service.changeItemStatus(itemId, event.target.checked).subscribe(data => { 
      this.getTodoList();
      this.resultMessage = 'Item updated successfully';
      this.showSuccessAlert();
    },
    (error) => {
      this.showError(error.error.error);
     })
   }

   showSuccessAlert(){
    this.classMessageAlert = 'alert alert-success'
    this.showAlertWithTimeout();
   }

   showError(errorMessage: any){ 
    this.resultMessage = errorMessage?? "System is temporary unavailable, sorry for the incovinience.";
    this.classMessageAlert = 'alert alert-danger'
    this.showAlertWithTimeout();
   }

   editItem(item:any) {  
    let date: string | null = null;

    if(item.deadline !== null) {  
      date = this.dateHelper.extractDateFromString(item.deadline); 
    }
     
    let value = {
      title: item.title,
      deadline: date??null
    };
   
    this.addItemForm?.setValue(value);
    this.itemEditedId = item.id;
    this.isEdit = true; 
   }

   deleteitem(itemId: number) {
    this.service.deleteTodo(itemId).subscribe(data => { 
      this.getTodoList();
      this.resultMessage = 'Item deleted successfully';
      this.showSuccessAlert();
    },
    (error) => {
      this.showError(error.error.error);
     })
   }

   showAlertWithTimeout() {
    this.showAlert = true;
        setTimeout(() => {
          this.showAlert = false;
        }, 3000);
  }
}