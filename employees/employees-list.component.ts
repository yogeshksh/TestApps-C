
  import { Component, OnInit } from '@angular/core';  
  import { Employee } from './models/employee';
  import { EmployeeDataService } from './services/employee-data.service';
  import { Observable, Subject } from "rxjs";
  import {debounceTime} from 'rxjs/operators';
  import { Router } from '@angular/router';  
  @Component({  
    selector: 'app-employees',  
    templateUrl: './employees-list.html',  
    styleUrls: ['../content/vendor/bootstrap/css/bootstrap.min.css',
    '../content/vendor/metisMenu/metisMenu.min.css',
    '../content/dist/css/sb-admin-2.css',
    '../content/vendor/font-awesome/css/font-awesome.min.css'
]
  })  
  export class EmployeesListComponent implements OnInit {  
    private employees: Employee[]; 
    private _employeeDataService; 
    massage:String;  
    dataSaved = false;
    output: any;
    errorMessage: any;
    constructor(private router: Router,private employeeDataService:EmployeeDataService) {
        this._employeeDataService = employeeDataService;
     }  
     LoadEmployees()  
     {  
       this._employeeDataService.GetAllEmployees()
         .subscribe(data =>
         {
           this.employees = data;
         });
     }  
   
    ngOnInit() 
    {  
        this.LoadEmployees();  
    }

    search(lastname: string): void
    {
      // wait 300ms after each keystroke before considering the 
      debounceTime(300);
      this._employeeDataService.GetEmployeesByLastName(lastname)
        .subscribe(data => {
          this.employees = data;
        });
    }
  }  
