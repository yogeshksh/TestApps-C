import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module'; 
import { FormsModule } from '@angular/forms';  
import { ReactiveFormsModule } from "@angular/forms";  
import { AppComponent } from "./app.component";
import { NgxPaginationModule} from 'ngx-pagination';  
import { Ng2SearchPipeModule } from 'ng2-search-filter';  
import { EmployeesListComponent } from './employees/employees-list.component';
import { EmployeeDataService } from './employees/services/employee-data.Service';


@NgModule({
  declarations: [AppComponent,EmployeesListComponent],
  imports: [HttpClientModule, BrowserModule,FormsModule,  
    AppRoutingModule,HttpClientModule,ReactiveFormsModule,Ng2SearchPipeModule,NgxPaginationModule],
  providers: [EmployeeDataService],
  bootstrap: [AppComponent]
})
export class AppModule {}
