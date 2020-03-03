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

  url:string="http://localhost:50951/Admin/"
  constructor(private http:HttpClient) { }
    public AddCategory(catg:Category):Observable<any>{
      return this.http.post<any>(this.url+'AddCategories',JSON.stringify(catg),Requestheaders);}
      public AddSubcategory(scatg:Subcategory):Observable<any>{
        return this.http.post<any>(this.url+'AddSubCategories',JSON.stringify(scatg),Requestheaders);}
        public DeleteCategory(categoryid:string):Observable<any>
        {
          return this.http.delete<any>(this.url+'Deletecategory/'+categoryid,Requestheaders);
        }
        public Viewcategory():Observable<any>
  {
    return this.http.get<any>(this.url+'Viewcategory',Requestheaders);
  }
  public Deletesubcategory(subcategoryid:string):Observable<any>
  {
    return this.http.delete<any>(this.url+'Deletesubcategory/'+subcategoryid,Requestheaders);
  }
  public Viewsubcategory():Observable<any>
  {
    return this.http.get<any>(this.url+'Viewsubcategory',Requestheaders);
  }
    }