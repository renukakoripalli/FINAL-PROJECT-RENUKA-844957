import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from '@angular/forms';
import { Items } from 'src/app/Models/items';
import { RegisterService } from 'src/app/Account/services/register.service';
import { SellerService } from '../services/seller.service';
@Component({
  selector: 'app-add-items',
  templateUrl: './add-items.component.html',
  styleUrls: ['./add-items.component.css']
})
export class AddItemsComponent implements OnInit {

  AddItemForm: FormGroup;
  submitted = false;
 list:Items[];
 item:Items;
  constructor(private formBuilder: FormBuilder,private sservice:SellerService) { }

  ngOnInit() {
      this.AddItemForm = this.formBuilder.group({
          Iid: ['',[Validators.required]],
          sid: ['',[Validators.required]],
          categoryid: ['',[Validators.required]],
          subcategoryid: ['',[Validators.required]],
          price: ['',[Validators.required]],
          stocknumber: ['',[Validators.required]],
          itemname:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],
          description:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],
          remarks:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]],    
          acceptTerms: [false, Validators.requiredTrue]
      });
  }
  get f(){
    return this.AddItemForm.controls;
  }
  onSubmit() {
    this.submitted = true;  
    //this.buyer=new Buyer(); 
    if (this.AddItemForm.valid) {
      this.Add();
  }
}
  Add() {
        this.item=new Items();
        this.item.Iid=this.AddItemForm.value["Iid"];
        this.item.categoryid=this.AddItemForm.value["categoryid"];
        this.item.subcategoryid=this.AddItemForm.value["subcategoryid"];
        this.item.price=this.AddItemForm.value["price"];
        this.item.stocknumber=this.AddItemForm.value["stocknumber"];
        this.item.sid=this.AddItemForm.value["sid"];
        this.item.itemname=this.AddItemForm.value["itemname"];
        this.item.description=this.AddItemForm.value["description"];
        this.item.remarks=this.AddItemForm.value["remarks"];
        // console.log(this.buyer);
        this.sservice.AddItem(this.item).subscribe(res=>{
          console.log('Added Items sucessfully')
        },err=>{
          console.log(err);
        })
        // alert('SUCCESS!! :-)\n\n') 
        // console.log(JSON.stringify(this.SignupForm.value)); 
      }


onReset() {
    this.submitted = false;
    this.AddItemForm.reset();
}
}
