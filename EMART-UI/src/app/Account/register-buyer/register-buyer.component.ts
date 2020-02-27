import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from '@angular/forms';
import { Buyer } from 'src/app/Models/buyer';
import { RegisterService } from '../Services/register.service';
import { resetFakeAsyncZone } from '@angular/core/testing';
import { Observable } from 'rxjs';
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
//itemForm:FormGroup;
b:Buyer[];

    constructor(private formBuilder: FormBuilder,private services:RegisterService) { }

    ngOnInit() {
        this.SignupForm = this.formBuilder.group({
            bid: ['',[Validators.required]],
            username:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],
            password:['',[Validators.required,Validators.pattern('^[a-z]{7}[~!@#$%^&*()]$')]],
            emailid: ['', [Validators.required,Validators.email]],
            mobilenumber:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
            createddatetime:['',[Validators.required]], 
            acceptTerms: [false, Validators.requiredTrue]
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.SignupForm.controls; }

    onSubmit() {
        this.submitted = true;  
        //this.buyer=new Buyer(); 
        if (this.SignupForm.valid) {
            this.items=new Buyer();
            this.items.bid=this.SignupForm.value["bid"];
            this.items.username=this.SignupForm.value["username"];
            this.items.password=this.SignupForm.value["password"];
            this.items.emailid=this.SignupForm.value["emailid"];
            this.items.mobilenumber=this.SignupForm.value["mobilenumber"];
            this.items.createddatetime=this.SignupForm.value["createddatetime"];
            // console.log(this.buyer);
            this.services.addBuyer(this.items).subscribe(res=>{
              console.log('buyer registered sucessfully')
            },err=>{
              console.log(err);
            })
            alert('SUCCESS!! :-)\n\n') 
            // console.log(JSON.stringify(this.SignupForm.value)); 
          }

    }

    onReset() {
        this.submitted = false;
        this.SignupForm.reset();
    }
}