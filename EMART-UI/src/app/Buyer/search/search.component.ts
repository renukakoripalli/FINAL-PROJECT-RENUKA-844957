import { Component, OnInit } from '@angular/core';

import { Items } from 'src/app/Models/items';
import { BuyerService } from '../services/buyer.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  list:Items[];
  constructor(private service:BuyerService) { }

  ngOnInit() {
  }
  Search(itemname:string){
    
    this.service.SearchItem(itemname).subscribe(res=>{
      this.list=res;
      console.log("success");
      console.log(this.list);
     
      })
    }
}