import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Buyer } from 'src/app/Models/buyer';
import { Seller } from 'src/app/Models/seller';
import { Token } from 'src/app/Models/token';
import { RegisterService } from '../services/register.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login: FormGroup;
    submitted = false;
    username:string;
    password:string;
    errmsg:string;
    buyer:Buyer;
    seller:Seller;
    role: any;
   token:Token;

    constructor(private formBuilder: FormBuilder,private route:Router,private service:RegisterService) { }

  ngOnInit() {
    this.login = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      role:['']
  });
}
// convenience getter for easy access to form fields
get f() { return this.login.controls; }

onSubmit() {
    this.submitted = true;
     // display form values on success
     }

onReset() {
    this.submitted = false;
    this.login.reset();
}
public Validate()
{
  let username=this.login.value['username'];
  let password=this.login.value['password'];
  let role=this.login.value['role'];
  this.token=new Token();
  //this.token=new Token();
  // alert(username)
  // alert(role)
  if(role=='buyer')
  {
    this.service.BuyerLogin(username,password).subscribe(res=>{
      console.log(res);
      this.token=res;

      if(this.token.msg=='Success'){
          this.route.navigateByUrl('buyer');
      }
      else{
        alert('Invalid Credentials');
      }
    });
  }
if(role=='seller')
{
 
this.service.SellerLogin(username,password).subscribe(res=>{
  console.log(res)
  this.token=res;
  if(this.token.msg=="Success"){
    this.route.navigateByUrl("seller")
  }
  else{
    alert('inavlid  Credentials');
  }
});

}
if(username=="Admin" && password=="admin")
{
  this.route.navigateByUrl("admin");
}
}
Navigate()
{
  switch(this.role){
    case "buyer":
      this.route.navigateByUrl("buyer");
      break;
      case "seller":
      this.route.navigateByUrl("seller");
      break;
      case "admin":
      this.route.navigateByUrl("admin");
      break;
      default:
        alert("invalid credentials");

 }
}
}

    