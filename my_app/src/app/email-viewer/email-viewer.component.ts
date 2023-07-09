import { Component } from '@angular/core';
import { EmailServiceService } from '../email-service.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-email-viewer',
  templateUrl: './email-viewer.component.html',
  styleUrls: ['./email-viewer.component.css']
})
export class EmailViewerComponent {

  constructor(private theEmailService:EmailServiceService){
    this.email.setValidators(Validators.email); 

  }
theEmail:string="";
theDateTime:Date =new Date();
isReceiveMessage:boolean =false;
isErrorReceived:boolean = false;

email = new FormControl('', [Validators.required, Validators.email]);

sendEmail(){
  this.isErrorReceived=false;

 this.theEmailService.sendDataToServer({"email":this.theEmail}).subscribe(
  (response) => {  
  console.log('response received :'+ response)
  this.updateDataFromServer(response)
},
(error) => {    
   if(error.status == 429)  
   this.updateDataFromServer(error.error)  
   this.isErrorReceived =true;  
  console.error('Request failed with error :'+  error.status)
},
() => {                                   
  console.log('Request completed')     
}
);
  
}
updateDataFromServer(response:any)
{
  this.isReceiveMessage=true;
  this.theEmail= response.email,
  this.theDateTime=response.dateTime 
}
}
