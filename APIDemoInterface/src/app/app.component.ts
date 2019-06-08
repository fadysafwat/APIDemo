import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private http:HttpClient) { }
  title = 'app';
  usersShow = false;
  userShow = false;
  insertShow = false;
  Data :any;
  isLogin:boolean = false;

  ngOnInit() {
    if (localStorage.getItem("token") != null) {
      this.isLogin=true;
    }
  }
  UsersShow(){
    this.usersShow = true;
    this.userShow = false;
    this.insertShow = false;
  }
  UserShow(){
    this.usersShow = false;
    this.userShow = true;
    this.insertShow = false;
  }
  InsertShow(){
    this.usersShow = false;
    this.userShow = false;
    this.insertShow = true;
  }

  Login(name:string,password:string){
    this.http.post('http://localhost:5000/api/Authontecation/login',{name:name,password:password}).subscribe(
      (responce:any)=>{localStorage.setItem('token',responce.token);this.isLogin=true; this.usersShow = false;
      this.userShow = false;
      this.insertShow = false;},
      error=>{alert("faild  !! ");console.log(error);}
    )
  }

  Regist(name:string,password:string){
    this.http.post('http://localhost:5000/api/Authontecation/registration',{name:name,password:password}).subscribe(
      responce=>{ alert("Data added successfully !! ");},
      error=>{alert("faild  !! ");console.log(error);}
    )
  }

  LogOut(){
    localStorage.removeItem('token');
    this.isLogin=false;
    this.usersShow = false;
      this.userShow = false;
      this.insertShow = false;
  }
}
