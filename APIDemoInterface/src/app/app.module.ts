import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { UsersComponent } from './Users/Users.component';
import { HttpClient } from 'selenium-webdriver/http';
import { UserComponent } from './User/User.component';
import { InsertComponent } from './Insert/Insert.component';
import { FormsModule } from '@angular/forms';

@NgModule({
   declarations: [
      AppComponent,
      UsersComponent,
      UserComponent,
      InsertComponent
      
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
