import { Component, OnInit } from '@angular/core';
import { Purchase } from 'src/app/Models/purchase';
import { BuyerService } from '../services/buyer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-purchase-history',
  templateUrl: './purchase-history.component.html',
  styleUrls: ['./purchase-history.component.css']
})
export class PurchaseHistoryComponent implements OnInit {

  phlist:Purchase[];
  count:number;
  constructor(private service:BuyerService,private route:Router) { 
    let bid=localStorage.getItem('bid');
    this.service.Purchasehistory(bid).subscribe(res=>{
      this.phlist=res;
      console.log(this.phlist);
    })

    if(localStorage.getItem('bid'))
    {
      let bid=localStorage.getItem('bid');
      this.service.GetCount(bid).subscribe(res=>{
        this.count=res;
      })
    }
  }

  ngOnInit() {
    
  }
}