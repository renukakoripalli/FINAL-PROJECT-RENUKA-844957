import { Component, OnInit } from '@angular/core';

import { Items } from 'src/app/Models/items';

import { Category } from 'src/app/Models/category';
import { Router } from '@angular/router';
//import { Cart } from 'src/app/Models/cart';
import { BuyerService } from '../services/buyer.service';
import { Cart } from 'src/app/Models/cart';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  list:Items[];
  isShow:boolean=true;
  clist:Category[];
  category:string;
  cart: any;
  constructor(private service:BuyerService,private route:Router) {
    this.service.Getcategory().subscribe(res=>{
      this.clist=res;
      console.log(this.clist);

      this.service.Getallitems().subscribe(res=>{
        this.list=res;
        console.log(this.list);
      })
    })
   }
   ngOnInit() {
    
  }
  Getallitems()
  {
    this.service.Getallitems().subscribe(res=>{
      this.list=res;
      console.log(this.list);
    })
  }
  Show(){
    this.isShow=!this.isShow;
  }
  Search(itemname:string){
    
    this.service.SearchItem(itemname).subscribe(res=>{
      this.list=res;
      console.log("success");
      console.log(this.list);
     
      })
    }
    SearchByCategory(categoryid:string){
      console.log(categoryid);
      this.service.SearchByCategoryId(categoryid).subscribe(res=>{
        this.list=res;
        console.log(this.list);
      })
    }
    AddtoCart(item2:Items){
      console.log(item2);
      let bid=localStorage.getItem('bid');
     this.cart=new Cart();
     this.cart.cartid='cartid'+Math.round(Math.random()*1000);
     this.cart.Iid=item2.Iid;
     this.cart.itemname=item2.itemname;
     this.cart.categoryid=item2.categoryid;
     this.cart.subcategoryid=item2.subcategoryid;
     this.cart.sid=item2.sid;
     this.cart.stocknumber=item2.stocknumber;
     this.cart.price=item2.price;
     this.cart.description=item2.description;
     this.cart.remarks=item2.remarks;
     this.cart.Photo=item2.Photo;
     this.cart.bid=bid;
     console.log(this.cart);
     this.service.AddtoCart(this.cart).subscribe(res=>{
       console.log("Record added To Cart");
       alert('Item has been Added To Cart');
     })
    }
  }