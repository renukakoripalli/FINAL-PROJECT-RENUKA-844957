import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from '@angular/forms'
import { Category } from 'src/app/Models/category';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {

  AddCategoryForm: FormGroup;
  submitted = false;

 catg:Category;
 
  constructor(private formBuilder: FormBuilder,private sservice:CategoryService) { }

  ngOnInit() {
      this.AddCategoryForm = this.formBuilder.group({
          categoryid: ['',[Validators.required]],
          categoryname: ['',[Validators.required]],
          briefdetails:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]], 
          acceptTerms: [false, Validators.requiredTrue]
      });
  }
  get f(){
    return this.AddCategoryForm.controls;
  }
  onSubmit() {
    this.submitted = true;  
    //this.buyer=new Buyer(); 
    if (this.AddCategoryForm.valid) {
        this.catg=new Category();
        this.catg.categoryid=this.AddCategoryForm.value["categoryid"];
        this.catg.categoryname=this.AddCategoryForm.value["categoryname"];
        this.catg.briefdetails=this.AddCategoryForm.value["briefdetails"];   
        console.log(this.catg);
        this.sservice.AddCategory(this.catg).subscribe(res=>{
          console.log('Added categories sucessfully')
        },err=>{
          console.log(err);
        })
         alert('SUCCESS!! :-)\n\n') 
        // console.log(JSON.stringify(this.SignupForm.value)); 
      }

}

onReset() {
    this.submitted = false;
    this.AddCategoryForm.reset();
}
// Delete()
//   {
//     let id1=this.AddCategoryForm.value["categoryid"];
//     console.log(id1);
//     this.sservice.DeleteCategory(id1).subscribe(res=>{
//       console.log('Category deleted');
//     },err=>{
//       console.log(err);
//     })
//   }
}
