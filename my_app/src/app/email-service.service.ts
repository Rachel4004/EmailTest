import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class EmailServiceService {

  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
   // accept: text/plain" -H  "Content-Type: application/json"
  };
  
  constructor(private http: HttpClient) { }

  sendDataToServer(data:{}): Observable<any>
  {    
 return this.http.post<any>("http://localhost:5007/Email",data);
  }
}
