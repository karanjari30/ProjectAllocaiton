import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Projectallocation } from './model/projectallocation';
import { Register } from './model/register';

@Injectable({
  providedIn: 'root'
})
export class ApiDataService {

  baseURL = `http://a640-106-201-236-89.ngrok.io`;

  registerUser: Register = {
    "Email": "sample string 1",
    "Password": "sample string 2",
    "ConfirmPassword": "sample string 3"
  }



  register(): Observable<Register> {
    return this.http.post<Register>(`${this.baseURL}/api/Account/Register`, this.registerUser)
  }

  login(email: string, password: string) {
    let body = new URLSearchParams();
    body.set('username', email);
    body.set('password', password);
    body.set('grant_type', "password");
    let header = new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded');
    return this.http.post(`${this.baseURL}/Token`, body, { headers: header });
  }

  getDataFromAPI(status: boolean) {
    return this.http.get(`${this.baseURL}/api/Project?status=` + status)
  }

  addProjectData(body:any): Observable<Projectallocation> {
    return this.http.post<Projectallocation>(`${this.baseURL}/api/Project`, body)
  }

  deleteProject(projectId: number){
    return this.http.patch(`${this.baseURL}/api/DeleteProjectByID?id=`+projectId, {})
  }
  constructor(private http: HttpClient) { }
}
