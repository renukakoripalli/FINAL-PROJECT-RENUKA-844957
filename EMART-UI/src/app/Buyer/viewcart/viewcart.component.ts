import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cart } from 'src/app/Models/cart';

import { Items } from 'src/app/Models/items';
import { BuyerService } from '../services/buyer.service';
@Component({
  selector: 'app-viewcart',
  templateUrl: './viewcart.component.html',
  styleUrls: ['./viewcart.component.css']
})
export class ViewcartComponent implements OnInit {
  cartlist:Cart;
  item:Items[];
  count: number;
  item1:Items;
  item_qty: number;
  item2:number;
 

  constructor(private route:Router,private service:BuyerService) {
   
  let bid=localStorage.getItem('bid'); 
    this.service.GetCartItems().subscribe(res=>{
      this.cartlist=res;
      console.log(this.cartlist);
    })

    if(localStorage.getItem('bid'))
    {
      let bid=localStorage.getItem('bid');
      this.service.GetCount(bid).subscribe(res=>{
        this.count=res;
      })
    }


    this.item_qty = 1;
  
  }
  ngOnInit() {
  }
  Buynow(item2:Items)
  {
    console.log(item2);
    this.item1=item2;
    console.log(item2);
    localStorage.setItem('item',JSON.stringify(this.item1));
    this.route.navigateByUrl('/buyer/buyproduct');
  }
  Remove(cartid:string)
  {
    console.log(cartid);
    this.service.RemoveCartItem(cartid).subscribe(res=>{
      console.log('item removed from cart');
      alert('Item removed from cart');
      window.location.reload();
    })
  }
  
  

    
}