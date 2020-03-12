import { Component, OnInit } from '@angular/core';
import { Items } from 'src/app/Models/items';
import { SellerService } from '../services/seller.service';
import {FormBuilder,FormGroup,Validators}from'@angular/forms';
import {Token} from 'src/app/Models/token';
import { Category } from 'src/app/Models/category';
import { Subcategory } from 'src/app/Models/subcategory';
@Component({
  selector: 'app-view-items',
  templateUrl: './view-items.component.html',
  styleUrls: ['./view-items.component.css']
})
export class ViewItemsComponent implements OnInit {

  itemform:FormGroup;
  submitted=false;
  item:Items;
  list:Items;
  num:number;
  list1:Items;
  Iid: string;
  sid:string;
id:string;
  token: Token;
  image:string;
  subcategorylist: Subcategory[];
  constructor(private formbuilder:FormBuilder,private service:SellerService) {
    this.id=JSON.parse(localStorage.getItem('sid')) ;
   this.service.Viewitems(this.id).subscribe(res=>
    {
      this.list=res;
      console.log(this.list);
    },
    err=>{
      console.log(err);
    }
    )
}
  ngOnInit() {
    this.itemform=this.formbuilder.group({
      Iid:[''],
       categoryid:[''],
      subcategoryid:[''],
      itemname:[''],
      description:[''],
      price:[''],
      stocknumber:[''],
      remarks:[''],
      sid:['']
    })
    
  }
  get f() { return this.itemform.controls; }
  Search(id:string){
    this.service.Getitems(id).subscribe(res=>{
      this.item=res;
      console.log(this.item);
      this.image=this.item.photo;
      this.itemform.setValue({
        Iid:this.item.iid,
        categoryid:this.item.categoryid,
        subcategoryid:this.item.subcategoryid,
        itemname:this.item.itemname,
        description:this.item.description,
        price:this.item.price,
        stocknumber:this.item.stocknumber,
        remarks:this.item.remarks,
        sid:this.item.sid
      })
  
  
    },err=>{
      console.log(err);
    })
  }

  
 
  Delete(iid:string):void{
    this.service.DeleteItem(iid).subscribe(res=>{
      console.log("record deleted");
      // this.Viewitems(this.id);
    },
    err=>
    {
      console.log(err);
    })
   
   }
   Update(){
    this.item=new Items();
    this.item.iid=(this.itemform.value["Iid"]);//I+Math.floor(Math.random()*10000)
    this.item.categoryid=this.itemform.value["categoryid"];
    this.item.subcategoryid=this.itemform.value["subcategoryid"];
    this.item.itemname=this.itemform.value["itemname"];
    this.item.description=this.itemform.value["description"];
    this.item.price=Number(this.itemform.value["price"]);
    this.item.stocknumber=Number(this.itemform.value["stocknumber"]);
    this.item.remarks=this.itemform.value["remarks"];
    this.item.sid=this.itemform.value["sid"];
    this.item.photo=this.image;
    console.log(this.item);
    this.service.Updateitem(this.item).subscribe(res=>{
      console.log('added');
      alert('Updated')
    },err=>{
      console.log(err);
    })
   
  }
  // Delete()
  // {
  
  // this.service.DeleteItem(this.Iid).subscribe(res=>
    
  //  {
  //    this.item=res;
  //    alert("successfully deleted") 
    
  //  }
  //   )
    
  // }
     
  
  view(sid:string)
  {
   this.list1=new Items()
    this.service.Viewitems(this.sid).subscribe(
      res=>{
        this.list1=res;
        console.log(this.list1)
        localStorage.setItem("Iid",this.list1.iid.toString())
        this.itemform.patchValue({
            itemname:this.list1.itemname,
            price:Number(this.list1.price),
            stocknumber:Number(this.list1.stocknumber),
            description:this.list1.description
          })
        })
   
  }  
  onReset() {
    this.submitted = false;
    this.itemform.reset();
  }
  
      
    GetSubcategory()
   {
     let categoryid=this.itemform.value["categoryid"];
     console.log(categoryid);
     this.service.Getsubcategory(categoryid).subscribe(res=>{
       this.subcategorylist=res;
       console.log(this.subcategorylist);
     })
   }
  }