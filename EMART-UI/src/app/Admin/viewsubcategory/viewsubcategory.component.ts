import { Component, OnInit } from '@angular/core';
import { Subcategory } from 'src/app/Models/subcategory';

import { FormGroup } from '@angular/forms';
import { CategoryService } from '../services/category.service';
@Component({
  selector: 'app-viewsubcategory',
  templateUrl: './viewsubcategory.component.html',
  styleUrls: ['./viewsubcategory.component.css']
})
export class ViewsubcategoryComponent implements OnInit {

  subcategory:Subcategory;
  constructor(private service:CategoryService) { }

  ngOnInit() {
    this.Viewsubcategory();
  }
  Deletesubcategory(subcategoryid:string):void{
    this.service.Deletesubcategory(subcategoryid).subscribe(res=>{
      console.log("record deleted");
      this.Viewsubcategory();
    },
    err=>
    {
      console.log(err);
    })
   
   }
   Viewsubcategory():void
    {
   this.service.Viewsubcategory().subscribe(res=>
     {
       this.subcategory=res;
       console.log(this.subcategory)
     },
     err=>{
       console.log(err);
     })
   }


}
