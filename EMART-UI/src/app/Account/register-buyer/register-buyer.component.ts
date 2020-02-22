import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from '@angular/forms';
@Component({
  selector: 'app-register-buyer',
  templateUrl: './register-buyer.component.html',
  styleUrls: ['./register-buyer.component.css']
})
export class RegisterBuyerComponent implements OnInit {

  SignupForm: FormGroup;
    submitted = false;

    constructor(private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.SignupForm = this.formBuilder.group({
            bid: ['', Validators.required],
            userame:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],
            password:['',[Validators.required,Validators.pattern('^[a-z]{7}[~!@#$%^&*()]$')]],
            emailid: ['', [Validators.required, Validators.email]],
            mobilenumber:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
            createddatetime:['',[Validators.required]],
            
            acceptTerms: [false, Validators.requiredTrue]
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.SignupForm.controls; }

    onSubmit() {
        this.submitted = true;
         // display form values on success
        if (this.SignupForm.valid) {
            alert('SUCCESS!! :-)\n\n') 
            console.log(JSON.stringify(this.SignupForm.value));
        }
    }

    onReset() {
        this.submitted = false;
        this.SignupForm.reset();
    }
}