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
      dateTime:[''],
      numberOfItems:[''],
      remarks:[''],
      transactionstatus:['']
    })

  }  
  onSubmit()
  {
    this.pobj=new Purchase();
    this.pobj.pid=Math.round(Math.random()*999);
    console.log(this.pobj.pid);
    this.pobj.bid=Number(localStorage.getItem('bid'));
    this.pobj.sid=Number(localStorage.getItem('sid'));
    this.pobj.noofitems=Number(this.purchaseform.value["numberOfItems"]);
    this.pobj.Iid=Number(this.item.iid);
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
    
  }