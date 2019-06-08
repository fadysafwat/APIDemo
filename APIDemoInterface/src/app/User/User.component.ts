import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-User',
  templateUrl: './User.component.html',
  styleUrls: ['./User.component.css']
})
export class UserComponent implements OnInit {
  ;Data:any;
  ShowEditTable:boolean =false;
  EditRowID:any='';
  constructor(private http:HttpClient) { }

  ngOnInit() {
  }

  token : any = localStorage.getItem('token');
  headers_object:any = new HttpHeaders({
   'Content-Type': 'application/json',
    'Authorization': "Bearer "+this.token})
    
  GetUser(id :number){
    this.http.get('http://localhost:5000/api/Users/'+id,{headers:this.headers_object}).subscribe(
      responce=>{this.Data=responce;alert("User Fetched successfully !! ");},
      error=>{console.log(error);alert("Unauthorized !! ");}
    )
  }
  DeleteUser(id : number){
    this.http.delete('http://localhost:5000/api/Users/'+id,{headers:this.headers_object}).subscribe(
      responce=>{this.GetUser(id);alert("User Deleted successfully !! ");},
      error=>{console.log(error);alert("Unauthorized !! ");}
    )
  }
  EditUser(id : number,name:string,state:boolean){
    this.http.put('http://localhost:5000/api/Users/'+id,{name:name,IsActive:state},{headers:this.headers_object}).subscribe(
      responce=>{this.GetUser(id);alert("User Edited successfully !! ");},
      error=>{console.log(error);alert("Unauthorized !! ");}
    )
  }

  SetID(val:number){
    this.EditRowID=val;
  }
  RemoveID(){
    this.EditRowID='';
  }
}
