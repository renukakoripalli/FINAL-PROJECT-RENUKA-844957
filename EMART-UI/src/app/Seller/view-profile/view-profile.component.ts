import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Seller } from 'src/app/Models/seller';
import { Items } from 'src/app/Models/items';
import { SellerService } from '../services/seller.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css']
})
export class ViewProfileComponent implements OnInit {

  seller:Seller;
Sellerform:FormGroup;
sid:string;
item:Items;
submitted=false;
  constructor( private route:Router, private form:FormBuilder,private service:SellerService) {
   
    let sid1=localStorage.getItem("sid") ;
    // this.myprofile()
    this.service.Myprofile("this.sid1").subscribe(res=>  
      {
        
        this.seller=res;
        console.log(this.seller);
        this.Sellerform.patchValue({
          sid1:this.seller.sid,
          username:this.seller.username,
          emailid:this.seller.emailid,
          password:this.seller.password,
          briefaboutcompany:this.seller.briefaboutcompany,
          companyname:this.seller.companyname,
          postaladdress:this.seller.postaladdress,
          website:this.seller.website,
          gstin:this.seller.gstin,
          contactnumber:this.seller.contactnumber,
          
        })
       })
   }
  
  ngOnInit() {
    this.Sellerform=this.form.group({
      
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
       
      }
     
      // myprofile()
      // {
      // this.service.Myprofile("this.sid").subscribe(res=>  
      //  {
         
      //    this.seller=res;
      //    console.log(this.seller);
      //    this.Sellerform.patchValue({
      //      sid:this.seller.sid,
      //      username:this.seller.username,
      //      emailid:this.seller.emailid,
      //      password:this.seller.password,
      //      briefaboutcompany:this.seller.briefaboutcompany,
      //      companyname:this.seller.companyname,
      //      postaladdress:this.seller.postaladdress,
      //      website:this.seller.website,
      //      gstin:this.seller.gstin,
      //      contactnumber:this.seller.contactnumber,
           
      //    })
      //   })
      // }
    
      // Edit()
      // {
      //   this.seller=new Seller();
      //   this.seller.sid=this.Sellerform.value["sid"],
      //   this.seller.username=this.Sellerform.value["username"],
      //   this.seller.emailid=this.Sellerform.value["emailid"],
      //   this.seller.password=this.Sellerform.value["password"],
      //   this.seller.briefaboutcompany=this.Sellerform.value["briefaboutcompany"],
      //   this.seller.companyname=this.Sellerform.value["companyname"],
      //   this.seller.postaladdress=this.Sellerform.value["postaladdress"],
      //   this.seller.website=this.Sellerform.value["website"],
      //   this.seller.contactnumber=this.Sellerform.value["contactnumber"],
      //   this.seller.gstin=this.Sellerform.value["gstin"],
      //   this.service.edit(this.seller).subscribe(res=>{console.log(this.seller),alert("updated succesfully"),this.myprofile()},err=>{
      //     console.log(err)
      //   })
      // }
    
    
      }
  

   
     
