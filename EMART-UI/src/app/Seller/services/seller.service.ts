import { Injectable } from '@angular/core';
import{HttpClient,HttpHeaders} from'@angular/common/http';
import {Observable} from 'rxjs';
import {Seller} from 'src/app/Models/seller';
import { Items } from 'src/app/Models/items';
import { Category } from 'src/app/Models/category';
import { Subcategory } from 'src/app/Models/subcategory';
const Requestheaders={headers:new HttpHeaders({'Content-Type':'application/json'})}
@Injectable({
  providedIn: 'root'
})
export class SellerService {
  url:string="http://localhost:50951/Item/"
  url1:string="http://localhost:50951/Seller/"
  constructor(private http:HttpClient) { }
    public AddItem(item:Items):Observable<any>{
      return this.http.post<any>(this.url+'AddItem',JSON.stringify(item),Requestheaders);}
      Myprofile(sid:number):Observable<Seller>
      {
       console.log(Requestheaders)
        return this.http.get<Seller>(this.url1+'GetProfile'+'/'+sid,Requestheaders);
      }
      edit(item:Seller):Observable<any>
      {
        return this.http.put<any>(this.url1+'EditProfile',item,Requestheaders);
      }
      public Getcategory():Observable<Category[]>
  {
    return this.http.get<Category[]>(this.url+'Getcategory',Requestheaders);
  }
  public Getsubcategory(categoryid:string):Observable<Subcategory[]>
  {
    return this.http.get<Subcategory[]>(this.url+'Getsubcategory/'+categoryid,Requestheaders);
  }
  public Viewitems(id:string):Observable<any>
  {
    return this.http.get<any>(this.url+'Viewitems/'+id,Requestheaders);
  }
  public Deleteitem(Iid:string):Observable<Items>
  {
    return this.http.delete<Items>(this.url+'Deleteitem/'+Iid,Requestheaders);
  }
  public Updateitem(items:Items):Observable<any>
  {
    return this.http.put<any>(this.url+'Update',items,Requestheaders);
  }
  public Getitems(Iid:string):Observable<Items>
  {
    return this.http.get<Items>(this.url+'GetItems/'+Iid,Requestheaders);
  }
  
        
}

     

  