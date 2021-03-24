import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable()
export class EmployeeService {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   

  }

  getAveSalary() {
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json'}); //service pages
    return this.http.get(this.baseUrl + 'api/Salary/AveSalary', { headers: reqHeader });
  }
}
