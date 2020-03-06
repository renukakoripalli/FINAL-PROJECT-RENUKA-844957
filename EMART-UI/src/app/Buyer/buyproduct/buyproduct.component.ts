import { Component, OnInit } from '@angular/core';
import { Items } from 'src/app/Models/items';
import { BuyerService } from '../services/buyer.service';

@Component({
  selector: 'app-buyproduct',
  templateUrl: './buyproduct.component.html',
  styleUrls: ['./buyproduct.component.css']
})
export class BuyproductComponent implements OnInit {

  list:Items[];
 

 
  constructor(private service:BuyerService) { 
    this.service.Getallitems().subscribe(res=>{
      this.list=res;
      console.log(this.list);
    })
  }

  ngOnInit() {
  }  
  
  }
