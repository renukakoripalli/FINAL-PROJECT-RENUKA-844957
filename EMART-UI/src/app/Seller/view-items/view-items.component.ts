import { Component, OnInit } from '@angular/core';
import { Items } from 'src/app/Models/items';
import { SellerService } from '../services/seller.service';

@Component({
  selector: 'app-view-items',
  templateUrl: './view-items.component.html',
  styleUrls: ['./view-items.component.css']
})
export class ViewItemsComponent implements OnInit {

  items:Items[];

  constructor(private service:SellerService) { }

  ngOnInit() {
    this.Viewitems();
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
   this.service.Viewitems().subscribe(res=>
     {
       this.items=res;
       console.log(this.items)
     },
     err=>{
       console.log(err);
     })
   }

}