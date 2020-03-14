import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from '@angular/forms';
import { Buyer } from 'src/app/Models/buyer';
import { RegisterService } from '../Services/register.service';

@Component({
  selector: 'app-register-buyer',
  templateUrl: './register-buyer.component.html',
  styleUrls: ['./register-buyer.component.css']
})
export class RegisterBuyerComponent implements OnInit {

  SignupForm: FormGroup;
    submitted = false;
    item:Buyer;
items:Buyer;

b:Buyer[];

    constructor(private formBuilder: FormBuilder,private services:RegisterService) { }

    ngOnInit() {
        this.SignupForm = this.formBuilder.group({
            
            username:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],
            password:['',[Validators.required,Validators.pattern('^[a-z]{7}[~!@#$%^&*()]$')]],
            emailid: ['', [Validators.required,Validators.email]],
            mobilenumber:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
            createddatetime:['',[Validators.required]], 
            acceptTerms: [false, Validators.requiredTrue]
        });
    }

   
    get f() { return this.SignupForm.controls; }

    onSubmit() {
        this.submitted = true;  
       
        if (this.SignupForm.valid) {
            this.items=new Buyer();
            this.items.bid=Math.floor(Math.random()*10).toString();
          
            this.items.username=this.SignupForm.value["username"];
          
            this.items.password=this.SignupForm.value["password"];
            this.items.emailid=this.SignupForm.value["emailid"];
            this.items.mobilenumber=this.SignupForm.value["mobilenumber"];
            this.items.createddatetime=this.SignupForm.value["createddatetime"];
            
            this.services.addBuyer(this.items).subscribe(res=>{
              console.log('buyer registered sucessfully')
            },err=>{
              console.log(err);
            })
            alert('SUCCESS!! :-)\n\n') 
            
          }

    }

    onReset() {
        this.submitted = false;
        this.SignupForm.reset();
    }
}