import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from '@angular/forms';

@Component({
  selector: 'app-register-seller',
  templateUrl: './register-seller.component.html',
  styleUrls: ['./register-seller.component.css']
})
export class RegisterSellerComponent implements OnInit {

  SignupForm: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.SignupForm = this.formBuilder.group({
            sid: ['', Validators.required],
        username:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],
        companyname:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],
        password:['',[Validators.required,Validators.pattern('^[a-z]{7}[~!@#$%^&*()]$')]],
       // spwd:['',[Validators.required,Validators.pattern('^[a-z]{7}[~!@#$%^&*()]$')]],
        emailid: ['', [Validators.required, Validators.email]],
        contactnumber:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
        briefaboutcompany:['',[Validators.required]],
        postal_address:['',[Validators.required]],
        GSTIN:['',[Validators.required]],
        website:['',Validators.required],
        acceptTerms: [false,Validators.requiredTrue]
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

