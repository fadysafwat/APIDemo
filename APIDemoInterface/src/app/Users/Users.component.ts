import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders,HttpResponse  } from '@angular/common/http';

@Component({
  selector: 'app-Users',
  templateUrl: './Users.component.html',
  styleUrls: ['./Users.component.css']
})
export class UsersComponent implements OnInit {
  TableData:any=[];
  ShowEditTable:boolean =false;
  EditRowID:any='';

  

  constructor(private http:HttpClient) { }

  ngOnInit() {
    this.getUsers();
  }

  token : any = localStorage.getItem('token');
   headers_object:any = new HttpHeaders({
    'Content-Type': 'application/json',
     'Authorization': "Bearer "+this.token})

  getUsers(){

    this.http.get('http://localhost:5000/api/Users',{headers:this.headers_object}).subscribe(
      responce=>{this.TableData=responce;},
      error=>{console.log(error);alert("Unauthorized !! ");}
    )
  }

  DeleteUser(id : number){
    this.http.delete('http://localhost:5000/api/Users/'+id,{headers:this.headers_object}).subscribe(
      responce=>{this.getUsers()},
      error=>{console.log(error);alert("Unauthorized !! ");}
    )
  }

  EditUser(id : number,name:string,state:boolean){
    this.http.put('http://localhost:5000/api/Users/'+id,{name:name,IsActive:state},{headers:this.headers_object}).subscribe(
      responce=>{},
      error=>{console.log(error);alert("Unauthorized !! ");}
    )
  }

  SetID(val:number){
    this.EditRowID=val;
  }

}
