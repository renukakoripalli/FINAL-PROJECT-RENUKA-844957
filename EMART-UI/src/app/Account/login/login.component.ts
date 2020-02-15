import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username:string;
  password:string;
  errmsg:string
    constructor(private route:Router) { }
  
    ngOnInit() {
    }
    public Validate()
    {
      if (this.username=="Renu"&& this.password=="12345") 
      {
        //set value in session
        sessionStorage.setItem("un",this.username)
        this.route.navigateByUrl('buyer') //user is name of the route
      }
      else if(this.username=="Rani"&&this.password=="123")
        {
          sessionStorage.setItem("un",this.username)
        this.route.navigateByUrl('seller')

        }
        else if(this.username=="jyo"&&this.password=="1234")
        {
          sessionStorage.setItem("un",this.username)
        this.route.navigateByUrl('admin')
        }
      
      else{
        this.errmsg="invalid login credentials";
      }
    }
  
  }
  