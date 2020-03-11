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
  bid:string;

  constructor(private route:Router,private service:BuyerService) {
    //let bid=localStorage.getItem('bid'); 
    // this.bid=JSON.parse(localStorage.getItem('bid')) ;
    this.bid=JSON.parse(localStorage.getItem('bid'))
    this.service.GetCartItems().subscribe(res=>{
      this.cartlist=res;
      console.log(this.cartlist);
    })
  }

  ngOnInit() {
  }
  Buynow(item1:Items)
  {
    console.log(item1);
    localStorage.setItem('item1',JSON.stringify(this.item));
    this.route.navigateByUrl('buyproduct');
  }
  Remove(cartid:string)
  {
    console.log(cartid);
    this.service.RemoveCartItem(cartid).subscribe(res=>{
      console.log('item removed from cart');
      alert('Item removed from cart');
    })
  }
  
}
