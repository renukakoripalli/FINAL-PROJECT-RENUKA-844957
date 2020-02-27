import { Injectable } from '@angular/core';
import{HttpClient,HttpHeaders} from'@angular/common/http';
import {Observable} from 'rxjs';
import { Category } from 'src/app/Models/category';
import { Subcategory } from 'src/app/Models/subcategory';
const Requestheaders={headers:new HttpHeaders({'Content-Type':'application/json'})}
@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  url:string="https://localhost:50951/Admin/"
  constructor(private http:HttpClient) { }
    public AddCategory(catg:Category):Observable<any>{
      return this.http.post<any>(this.url+'AddCategory',JSON.stringify(catg),Requestheaders);}
      public AddSubcategory(scatg:Subcategory):Observable<any>{
        return this.http.post<any>(this.url+'AddSubCategory',JSON.stringify(scatg),Requestheaders);}

    }