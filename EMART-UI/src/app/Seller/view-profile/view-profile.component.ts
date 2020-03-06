import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Seller } from 'src/app/Models/seller';
import { Router } from '@angular/router';
import { SellerService } from '../services/seller.service';
//import { Router } from '@angular/router';
@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css']
})
export class ViewProfileComponent implements OnInit {

  Sellform:FormGroup;
  submitted=false;
  list:Seller[];
  seller:Seller;
  sid:number;
  constructor(private route:Router,private builder:FormBuilder,private service:SellerService) {
    this.sid=Number(localStorage.getItem('sid'));
   }
  
  ngOnInit() {
    this.Sellform=this.builder.group({
      
        sid:['',[Validators.required]],
        username:['',[Validators.required]],
        password:['',[Validators.required]],
        companyname:['',[Validators.required]],
        gstin:['',[Validators.required]],
        briefaboutcompany:['',[Validators.required]],
        postaladdress:['',[Validators.required]],
        website:['',[Validators.required]],
        emailid:['',[Validators.required,Validators.email]],
        contactnumber:['',[Validators.required]]
        }) 
        this.myprofile()
      }
     
  
  get f()
  {
     return this.Sellform.controls; 
  }

 
  Onsubmit()
  {
    this.submitted =true;
      if(this.Sellform.valid){
        this.myprofile()
      }
  }
  myprofile()
  {
   
  this.service.Myprofile(this.sid).subscribe(res=>
    
   {
     this.seller=res;
     console.log(this.seller);
     this.Sellform.patchValue({
       
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
    this.seller.sid=localStorage.getItem('sid'),
    this.seller.username=this.Sellform.value["username"],
    this.seller.emailid=this.Sellform.value["emailid"],
    this.seller.password=this.Sellform.value["password"],
    this.seller.briefaboutcompany=this.Sellform.value["briefaboutcompany"],
    this.seller.companyname=this.Sellform.value["companyname"],
    this.seller.postaladdress=this.Sellform.value["postaladdress"],
    this.seller.website=this.Sellform.value["website"],
    this.seller.contactnumber=this.Sellform.value["contactnumber"],
    this.seller.gstin=this.Sellform.value["gstin"],
    this.service.edit(this.seller).subscribe(res=>{console.log(this.seller),alert("updated succesfully"),this.myprofile()},err=>{
      console.log(err)
    })
  }
}
   
     
