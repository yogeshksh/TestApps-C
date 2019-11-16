import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs'
import { catchError, tap, map } from 'rxjs/operators'
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Employee} from '../models/employee';

@Injectable({
    providedIn: 'root'
})

export class EmployeeDataService {

  private apiUrl = "https://localhost:5001/api/Employees";
  constructor(private http: HttpClient)
  {
       
  }
  //Get all employees
  public GetAllEmployees(): Observable<Employee[]> {
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.get<Employee[]>(this.apiUrl, { headers: headers });
  }  

    // Get all employees By lastname
    public GetEmployeesByLastName(lastName) {
        var url = this.apiUrl + '/' + lastName;
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.get<Employee>(url, { headers: headers }).pipe(tap(data => data),
            catchError(this.handleError)
        );
    }  

    private handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error(`Backend returned code ${error.status}, ` + `body was: ${error.error}`);
        }
        // return an observable with a user-facing error message
        return throwError('Something bad happened; please try again later.');
    };
}
