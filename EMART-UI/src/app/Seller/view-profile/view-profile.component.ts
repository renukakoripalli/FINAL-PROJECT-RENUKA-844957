import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Seller } from 'src/app/Models/seller';

import { SellerService } from '../services/seller.service';
//import { Router } from '@angular/router';
@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css']
})
export class ViewProfileComponent implements OnInit {

  editprofileform: FormGroup;
    submitted = false;
    seller:Seller;
    list:Seller[];
    constructor(private formbuilder: FormBuilder,private service:SellerService) { }

    ngOnInit() {
        this.editprofileform = this.formbuilder.group({
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
        this.GetProfile()
    }
    get f()
    {
       return this.editprofileform.controls; 
    }
  
   
    Onsubmit()
    {
      this.submitted =true;
        if(this.editprofileform.valid){
          this.GetProfile()
        }
    }
   GetProfile()
    {
      let sid=12345;
    this.service.GetProfile(sid).subscribe(res=>
      
     {
       this.seller=res;
       console.log(this.seller);
       this.editprofileform.patchValue({
         sid:this.seller.sid,
         username:this.seller.username,
         emailid:this.seller.emailid,
         password:this.seller.password,
         briefaboutcompany:this.seller.briefaboutcompany,
         companyname:this.seller.companyname,
         postaladdress:this.seller.postaladdress,
         website:this.seller.website,
         contactnumber:this.seller.contactnumber,
          gstin:this.seller.gstin
       })
      
    })}
    Edit()
    {
    
      this.seller=new Seller();
      this.seller.sid=this.editprofileform.value["sid"],
      this.seller.username=this.editprofileform.value["username"],
      this.seller.emailid=this.editprofileform.value["emailid"],
      this.seller.password=this.editprofileform.value["password"],
      this.seller.briefaboutcompany=this.editprofileform.value["briefaboutcompany"],
      this.seller.companyname=this.editprofileform.value["companyname"],
      this.seller.postaladdress=this.editprofileform.value["postaladdress"],
      this.seller.website=this.editprofileform.value["website"],
      this.seller.contactnumber=this.editprofileform.value["contactnumber"],
      this.seller.gstin=this.editprofileform.value["gstin"],
      this.service.EditProfile(this.seller).subscribe(res=>{console.log(this.seller),alert("updated succesfully"),this.GetProfile()},err=>{
        console.log(err)
      })
    }
  }

  
   
     
