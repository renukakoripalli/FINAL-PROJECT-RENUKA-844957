import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Seller } from 'src/app/Models/seller';

import { SellerService } from '../services/seller.service';
@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css']
})
export class ViewProfileComponent implements OnInit {

  editprofilesForm: FormGroup;
    submitted = false;
    seller:Seller;

    constructor(private formBuilder: FormBuilder,private service:SellerService) { }

    ngOnInit() {
        this.editprofilesForm = this.formBuilder.group({
            sid:['',[Validators.required]],
            username:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],
            password:['',[Validators.required,Validators.pattern('^[a-z]{7}[~!@#$%^&*()]$')]],
            companyname:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],
            gstin:['',[Validators.required,Validators.pattern('^[a-z]{3,10}$')]],
            briefaboutcompany:['',[Validators.required]],
            postaladdress:['',[Validators.required]],
            website:['',[Validators.required]],
            emailid: ['', [Validators.required, Validators.email]],
            contactnumber:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
             
            
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.editprofilesForm.controls; }

    onSearch(){
        let sid=this.editprofilesForm.value["sid"];
        this.service.GetProfile(sid).subscribe(res=>
          {
              this.seller=res;
              console.log(this.seller);
              this.editprofilesForm.setValue({
               sid:this.seller.sid,
               username:this.seller.username,
               password:this.seller.password,
               companyname:this.seller.companyname,
               gstin:this.seller.gstin,
               briefaboutcompany:this.seller.briefaboutcompany,
               postaladdress:this.seller.postaladdress,
               website:this.seller.website,
               emailid:this.seller.emailid,
               contactnumber:this.seller.contactnumber
               
    
             })
          },err=>{
            console.log(err)
          })
      }
    
      onSubmit() {
          
          this.submitted = true;
           // display form values on success
           if (this. editprofilesForm.valid) {
            this.seller=new Seller();
           this.seller.sid=this.editprofilesForm.value["sid"];
           
        this.seller.username=this.editprofilesForm.value["username"];
        this.seller.password=this.editprofilesForm.value["password"];
        this.seller.companyname=this.editprofilesForm.value["companyname"];
        this.seller.gstin=this.editprofilesForm.value["gstin"];
        this.seller.briefaboutcompany=this.editprofilesForm.value["briefaboutcompany"];
        this.seller.postaladdress=this.editprofilesForm.value["postaladdress"];
        this.seller.website=this.editprofilesForm.value["website"];
        this.seller.emailid=this.editprofilesForm.value["emailid"];
        this.seller.contactnumber=this.editprofilesForm.value["contactnumber"];
        this.service.Editprofile(this.seller).subscribe(res=>{
        console.log('Record Updated')
        },err=>{
        console.log(err)
        })
            alert('SUCCESS!! :-)\n\n') 
            // console.log(JSON.stringify(this.SignupForm.value));
        }
      }
    onReset() {
        this.submitted = false;
        this.editprofilesForm.reset();
    }
  }
