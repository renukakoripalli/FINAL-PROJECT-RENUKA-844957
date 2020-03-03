import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/Models/category';

import { FormGroup } from '@angular/forms';
import { CategoryService } from '../services/category.service';
@Component({
  selector: 'app-viewcategory',
  templateUrl: './viewcategory.component.html',
  styleUrls: ['./viewcategory.component.css']
})
export class ViewcategoryComponent implements OnInit {

  category:Category[];
  constructor(private service:CategoryService) { }

  ngOnInit() {
    this.Viewcategory();
  }

  Deletecategory(cid:string):void{
    this.service.DeleteCategory(cid).subscribe(res=>{
      console.log("record deleted");
      this.Viewcategory();
    },
    err=>
    {
      console.log(err);
    })
   
   }
   Viewcategory():void
    {
   this.service.Viewcategory().subscribe(res=>
     {
       this.category=res;
       console.log(this.category)
     },
     err=>{
       console.log(err);
     })
   }

}
