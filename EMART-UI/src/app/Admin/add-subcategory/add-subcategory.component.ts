import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from '@angular/forms'
import { Subcategory } from 'src/app/Models/subcategory';
import { CategoryService } from '../services/category.service';
import { Category } from 'src/app/Models/category';
@Component({
  selector: 'app-add-subcategory',
  templateUrl: './add-subcategory.component.html',
  styleUrls: ['./add-subcategory.component.css']
})
export class AddSubcategoryComponent implements OnInit {

  AddSubCategoryForm: FormGroup;
  submitted = false;
  category:Subcategory;
  categories:Category[];
  subcategories:Subcategory;

 scatg:Subcategory;
  constructor(private formBuilder: FormBuilder,private sservice:CategoryService) { }

  ngOnInit() {
      this.AddSubCategoryForm = this.formBuilder.group({
        subcategoryid: ['',[Validators.required]],
          subcategoryname: ['',[Validators.required]],
          categoryname:['',[Validators.required]],
          categoryid: ['',[Validators.required]],
          briefdetails:['',[Validators.required,Validators.pattern('^[a-z]{3,20}$')]], 
          GST:['',[Validators.required]],
          acceptTerms: [false, Validators.requiredTrue]
      });
      this.Getcategory();
  }

  get f()
  {
    return this.AddSubCategoryForm.controls;
  }
  onSubmit() {
    this.submitted = true;  
   
    if (this.AddSubCategoryForm.valid) {
      this.Add();
  }
}
  Add(){
    
    if (this.AddSubCategoryForm.valid) {
        this.scatg=new Subcategory();
      
        this.scatg.categoryid=this.AddSubCategoryForm.value["CategoryName"];
        this.scatg.subcategoryid=this.AddSubCategoryForm.value["subcategoryid"]
        this.scatg.subcategoryname=this.AddSubCategoryForm.value["subcategoryname"];
        this.scatg.briefdetails=this.AddSubCategoryForm.value["briefdetails"];  
        this.scatg.GST=this.AddSubCategoryForm.value["GST"]; 
        console.log(this.scatg);
        this.sservice.AddSubcategory(this.scatg).subscribe(res=>{
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
    this.AddSubCategoryForm.reset();
}
Getcategory()
   {
     this.sservice.Viewcategory().subscribe(res=>
      {
        this.categories=res;
        console.log(this.categories);
      },
      err=>
      {
        console.log(err);
      })
    }
}