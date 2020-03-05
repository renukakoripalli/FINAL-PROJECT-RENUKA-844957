import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from '@angular/forms';
import { Items } from 'src/app/Models/items';
import { RegisterService } from 'src/app/Account/services/register.service';
import { SellerService } from '../services/seller.service';
import { Category } from 'src/app/Models/category';
import { Subcategory } from 'src/app/Models/subcategory';
@Component({
  selector: 'app-add-items',
  templateUrl: './add-items.component.html',
  styleUrls: ['./add-items.component.css']
})
export class AddItemsComponent implements OnInit {

  additemsForm: FormGroup;
    submitted = false;
    items:Items;
    categorylist:Category[];
    subcategorylist:Subcategory[];
Photo:string;
    constructor(private formBuilder: FormBuilder,private service:SellerService) {
      this.service.Getcategory().subscribe(res=>{
        this.categorylist=res;
        console.log(this.categorylist);
      })
     }
    ngOnInit() {

    this.additemsForm = this.formBuilder.group({
      Iid: ['', Validators.required],
      categoryid: ['', Validators.required],
      subcategoryid: ['', [Validators.required]],
      // Sid: ['', [Validators.required]],
      itemname:['',[Validators.required]],
      price:['',[Validators.required]],
      description:['',[Validators.required]],
      stocknumber:['',[Validators.required]],
      remarks:['',[Validators.required]],
      Photo:['',[Validators.required]]

    
  });
  }

// convenience getter for easy access to form fields
get f() { return this.additemsForm.controls; }



onGetsubcategory()
  {
    let categoryid=this.additemsForm.value["categoryid"];
    console.log(categoryid);
    this.service.Getsubcategory(categoryid).subscribe(res=>{
      this.subcategorylist=res;
      console.log(this.subcategorylist);
    })
  }

onSubmit() {
  this.submitted = true;
   // display form values on success
   if(this.additemsForm.valid){
    this.items=new Items();
    this.items.Iid=(this.additemsForm.value["Iid"]),  
    this.items.categoryid=this.additemsForm.value["categoryid"],
    this.items.subcategoryid=this.additemsForm.value["subcategoryid"],
    // this.items.sid=this.additemsForm.value["Sid"],  
    this.items.itemname=this.additemsForm.value["itemname"],
    this.items.price=Number(this.additemsForm.value["price"]),
    this.items.description=this.additemsForm.value["description"],  
    this.items.stocknumber=Number(this.additemsForm.value["stocknumber"]),
    this.items.remarks=this.additemsForm.value["remarks"],
    this.items.Photo=this.Photo;
    console.log(this.items);
    this.service.AddItem(this.items).subscribe(res=>{
      console.log('Items Added');
    },err=>{
      console.log(err);
    })
    alert('SUCCESS!! :-)\n\n') 
  }
  
}
fileEvent(event){
  this.Photo = event.target.files[0].name;
}
onReset() {
  this.submitted = false;
  this.additemsForm.reset();
}
}
