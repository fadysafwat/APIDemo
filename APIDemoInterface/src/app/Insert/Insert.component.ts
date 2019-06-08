import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Statement } from '@angular/compiler';

@Component({
  selector: 'app-Insert',
  templateUrl: './Insert.component.html',
  styleUrls: ['./Insert.component.css']
})
export class InsertComponent implements OnInit {

  constructor(private http:HttpClient) { }

  ngOnInit() {
  }

  token : any = localStorage.getItem('token');
  headers_object:any = new HttpHeaders({
   'Content-Type': 'application/json',
    'Authorization': "Bearer "+this.token})
    
  bool:any =true;
  onSubmit(name:string,state:number){
    if (state == 0)this.bool = false;
    this.http.post('http://localhost:5000/api/Users/',{name:name,IsActive:this.bool},{headers:this.headers_object}).subscribe(
      responce=>{ alert("User added successfully !! ");},
      error=>{console.log(error);alert("Unauthorized !! ");}
    )
  }
}
