import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from '@angular/forms';
import { Seller } from 'src/app/Models/seller';
import { RegisterService } from '../Services/register.service';
@Component({
  selector: 'app-register-seller',
  templateUrl: './register-seller.component.html',
  styleUrls: ['./register-seller.component.css']
})
export class RegisterSellerComponent implements OnInit {

  SignupForm: FormGroup;
  submitted = false;
list:Seller[];
sellers:Seller;
  constructor(private formBuilder: FormBuilder,private service:RegisterService) { }

  ngOnInit() {
    this.SignupForm = this.formBuilder.group({
            
        username:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],
        companyname:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],
        password:['',[Validators.required,Validators.pattern('^[a-z]{7}[~!@#$%^&*()]$')]],      
        emailid: ['', [Validators.required, Validators.email]],
        contactnumber:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
        briefaboutcompany:['',[Validators.required]],
       
        postaladdress:['',[Validators.required]],
        gstin:['',[Validators.required]],
        website:['',Validators.required],
        acceptTerms: [false,Validators.requiredTrue]
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.SignupForm.controls; }

  onSubmit()
  {
  this.submitted=true;
  if(this.SignupForm.valid){
    this.Add();
  }
  
}
onReset() {
  this.submitted = false;
  this.SignupForm.reset();
}
Add()
{
  this.sellers=new Seller();
  this.sellers.sid=Math.floor(Math.random()*10).toString();
      this.sellers.username=this.SignupForm.value["username"];
      this.sellers.password=this.SignupForm.value["password"];
      this.sellers.emailid=this.SignupForm.value["emailid"];
      this.sellers.contactnumber=this.SignupForm.value["contactnumber"];
      this.sellers.briefaboutcompany=this.SignupForm.value["briefaboutcompany"];
      this.sellers.companyname=this.SignupForm.value["companyname"];
      this.sellers.gstin=this.SignupForm.value["gstin"];
      this.sellers.postaladdress=this.SignupForm.value["postaladdress"];
      this.sellers.website=this.SignupForm.value["website"];
      
  this.service.addSeller(this.sellers).subscribe(res=>{console.log('seller registered')},
   err=>{console.log(err);});


      }
 reset(){
 alert("Successfully registered");
  this.SignupForm.reset();
 }

}


