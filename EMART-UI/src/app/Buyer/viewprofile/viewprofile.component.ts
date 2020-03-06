import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Buyer } from 'src/app/Models/buyer';
//import { SellerService } from 'src/app/Seller/seller.service';
import { BuyerService } from '../services/buyer.service';

@Component({
  selector: 'app-viewprofile',
  templateUrl: './viewprofile.component.html',
  styleUrls: ['./viewprofile.component.css']
})
export class ViewprofileComponent implements OnInit {
  Buyerform:FormGroup;
  submitted:boolean=false;
  item:Buyer;
  constructor(private form:FormBuilder,private service:BuyerService) {
    
    console.log("hello")
    this.ViewProfile();
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
  }
ViewProfile(){

  let bid=1234;
  this.service.Myprofile(bid).subscribe(res=>{this.item=res;
  console.log(this.item)
  this.Buyerform.patchValue({
    id:this.item.bid,
    username:this.item.username,
    email:this.item.emailid,
    createdatetime:this.item.createddatetime,
    password:this.item.password,
    mobilenumber:this.item.mobilenumber

  })
},
  err=>{
    console.log(err);
  }
  )}
  Onsubmit(){
    alert("safsd")
    this.submitted=true;
    if(this.Buyerform.valid){
      this.ViewProfile();
    }
  }
 
  Edit()
  {
  
    this.item=new Buyer();
    this.item.bid=localStorage.getItem('bid'),
    this.item.username=this.Buyerform.value["username"],
    this.item.emailid=this.Buyerform.value["emailid"],
    this.item.password=this.Buyerform.value["password"],
    this.item.mobilenumber=this.Buyerform.value["mobilenumber"],
    this.item.createddatetime=new Date(this.Buyerform.value["createddatetime"])
    this.service.edit(this.item).subscribe(res=>{console.log(this.item),alert("updated succesfully")},err=>{
      console.log(err)
    })
  }
 

}
