import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Buyer } from 'src/app/Models/buyer';
//import { SellerService } from 'src/app/Seller/seller.service';
import { BuyerService } from '../services/buyer.service';
import {Token} from 'src/app/Models/token';
import { Router } from '@angular/router';
@Component({
  selector: 'app-buyerprofile',
  templateUrl: './buyerprofile.component.html',
  styleUrls: ['./buyerprofile.component.css']
})
export class BuyerprofileComponent implements OnInit {
  Buyerform:FormGroup
  submitted=false;
  buyer:Buyer;
    token: Token;
    bid:number;
    constructor(private route:Router,private form:FormBuilder,private service:BuyerService) {
     
      console.log(localStorage.getItem('bid'));
      this.bid=JSON.parse(localStorage.getItem('bid')) ;
      console.log(this.bid);
   
      
     }
  
    ngOnInit() {
      this.Buyerform=this.form.group({
        bid:['',[Validators.required]],
        username:['',[Validators.required,Validators.pattern("^[A-Z]{6,15}$")]],
        createddatetime:['',[Validators.required]],
        mobilenumber:['',[Validators.required,Validators.pattern("^[6-9][0-9]{7}$")]],
        
        emailid:['',[Validators.required,Validators.email]],
        password:['',[Validators.required,Validators.pattern("^(?=.*[A-Z]).{8,30}$")]]
    });
    this.Getprofile();
    }
    Getprofile()
    {
     
    this.service.Getprofile(this.bid).subscribe(res=>  
     {
       
       this.buyer=res;
       console.log(this.buyer);
       this.Buyerform.patchValue({
         bid:this.buyer.bid,
         username:this.buyer.username,
         emailid:this.buyer.emailid,
         password:this.buyer.password,
         createddatetime:this.buyer. createddatetime,
         mobilenumber:this.buyer.mobilenumber,
       })
      })
  
      }
      Edit()
      {
        this.buyer=new Buyer();
        this.buyer.bid=this.Buyerform.value["bid"],
        this.buyer.username=this.Buyerform.value["username"],
        this.buyer.emailid=this.Buyerform.value["emailid"],
        this.buyer.password=this.Buyerform.value["password"],
        this.buyer.mobilenumber=this.Buyerform.value["mobilenumber"],
        this.buyer.createddatetime=this.Buyerform.value["createddatetime"],
        this.service.edit(this.buyer).subscribe(res=>{console.log(this.buyer),alert("updated succesfully"),this.Getprofile()},err=>{
          console.log(err)
        })
      }
    
    
  
    }