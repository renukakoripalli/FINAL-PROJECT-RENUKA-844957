import { Component, OnInit } from '@angular/core';
import { Items } from 'src/app/Models/items';
import { BuyerService } from '../services/buyer.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Purchase } from 'src/app/Models/purchase';
import { Router } from '@angular/router';

@Component({
  selector: 'app-buyproduct',
  templateUrl: './buyproduct.component.html',
  styleUrls: ['./buyproduct.component.css']
})
export class BuyproductComponent implements OnInit {

  purchaseform:FormGroup;
  item:Items;
  pobj:Purchase;
  submitted=false;
  total:number;
id:number;
 
  constructor(private formbuilder:FormBuilder,private service:BuyerService,private route:Router) {  
    this.item=JSON.parse(localStorage.getItem('item1'));
    console.log(this.item);
    console.log(this.item.iid);
    
    }
    

  ngOnInit() {
    this. purchaseform=this.formbuilder.group({
      
      transactionType:[''],
      cardNumber:[''],
      cvv:[''],
      edate:[''],
      name:[''],
      price:[''],
      dateTime:[''],
      noofitems:[''],
      remarks:[''],
      transactionstatus:['']
    })

  }  
  onSubmit()
  {
    this.pobj=new Purchase();
    this.pobj.pid=Math.round(Math.random()*999).toString();
    console.log(this.pobj.pid);
    this.pobj.bid=localStorage.getItem('bid').toString();
    this.pobj.sid=localStorage.getItem('sid').toString();
    this.pobj.noofitems=Number(this.purchaseform.value["noofitems"]);
    this.pobj.Iid=this.item.iid.toString();
    this.pobj.transactiontype=this.purchaseform.value["transactionType"]
       this.pobj.datetime=this.purchaseform.value["dateTime"];
       this.pobj.remarks=this.purchaseform.value["remarks"];
       this.pobj.transactionstatus=this.purchaseform.value["transactionstatus"];
       console.log(this.pobj);
       this.service.BuyItem(this.pobj).subscribe(res=>{
         console.log("Purchase was Sucessfull");
         alert('Purchase Done Successfully');
       })
  
  }
  onReset() {
    this.submitted = false;
    this.purchaseform.reset();
  }
  
  Add(event){
    this.id=Number(this.purchaseform.value['noofitems'])
     
       console.log(this.total=this.id*this.item.price);
     
       
   }
    
  }