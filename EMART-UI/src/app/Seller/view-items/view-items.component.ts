import { Component, OnInit } from '@angular/core';
import { Items } from 'src/app/Models/items';
import { SellerService } from '../services/seller.service';
import {FormBuilder,FormGroup,Validators}from'@angular/forms';
import { Category } from 'src/app/Models/category';
import { Subcategory } from 'src/app/Models/subcategory';
@Component({
  selector: 'app-view-items',
  templateUrl: './view-items.component.html',
  styleUrls: ['./view-items.component.css']
})
export class ViewItemsComponent implements OnInit {

  items:Items;
  list:Items;
  itemForm:FormGroup;
  category:Category[];
  categorylist:Category[];
  subcategorylist:Subcategory[];
  sid:string;

  constructor(private service:SellerService,private formbuilder:FormBuilder ) { 
  // this.sid=localStorage.getItem('sid');
  // this.Viewitems()
  }
  ngOnInit() {
    this.itemForm=this.formbuilder.group({
      Iid:[''],
       categoryid:[''],
      subcategoryid:[''],
      itemname:[''],
      description:[''],
      price:[''],
      stocknumber:[''],
      remarks:[''],
      sid:[''],
      Photo:['']
    })
    this.Viewitems();
  }
  Search(id:string){
    this.service.Getitems(id).subscribe(res=>{
      this.items=res;
      console.log(this.items);
      this.itemForm.setValue({
        Iid:this.items.Iid,
        categoryid:this.items.categoryid,
        subcategoryid:this.items.subcategoryid,
        itemname:this.items.itemname,
        description:this.items.description,
        price:this.items.price,
        stocknumber:this.items.stocknumber,
        remarks:this.items.remarks,
        sid:this.items.sid,
        Photo:this.items.Photo
      })
  
  
    },err=>{
      console.log(err);
    })
  }

  
  Update(){
      this.items=new Items();
      this.items.Iid=(this.itemForm.value["Iid"]);//I+Math.floor(Math.random()*10000)
      this.items.categoryid=this.itemForm.value["categoryid"];
      this.items.subcategoryid=this.itemForm.value["subcategoryid"];
      this.items.itemname=this.itemForm.value["itemname"];
      this.items.description=this.itemForm.value["description"];
      this.items.price=Number(this.itemForm.value["price"]);
      this.items.stocknumber=Number(this.itemForm.value["stocknumber"]);
      this.items.remarks=this.itemForm.value["remarks"];
      this.items.sid=this.itemForm.value["sid"];
      this.items.Photo=this.itemForm.value["Photo"];
      console.log(this.items);
      this.service.Updateitem(this.items).subscribe(res=>{
        console.log('added');
        alert('Updated')
      },err=>{
        console.log(err);
      })
     
    }
  Deleteitem(Iid:string):void{
    this.service.Deleteitem(Iid).subscribe(res=>{
      console.log("record deleted");
      this.Viewitems();
    },
    err=>
    {
      console.log(err);
    })
   
   }
   Viewitems():void
   {
  this.service.Viewitems("2").subscribe(res=>
    {
      this.list=res;
      console.log(this.list)
    },
    err=>{
      console.log(err);
    })
  }

      
   GetSubcategory()
   {
     let categoryid=this.itemForm.value["categoryid"];
     console.log(categoryid);
     this.service.Getsubcategory(categoryid).subscribe(res=>{
       this.subcategorylist=res;
       console.log(this.subcategorylist);
     })
   }

}