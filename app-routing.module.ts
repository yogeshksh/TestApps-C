import { NgModule } from '@angular/core';  
import { Routes, RouterModule } from '@angular/router';  
import { EmployeesListComponent } from "./employees/employees-list.component";  
  
const routes: Routes = [  
  { path: "All", component: EmployeesListComponent },
  { path: "", component: EmployeesListComponent },  
];  
  
@NgModule({  
  imports: [RouterModule.forRoot(routes)],  
  exports: [RouterModule]  
})  
export class AppRoutingModule { }  
