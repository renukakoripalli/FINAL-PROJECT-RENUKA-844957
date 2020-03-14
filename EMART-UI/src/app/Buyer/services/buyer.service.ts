import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { Buyer } from 'src/app/Models/buyer';
import { Items } from 'src/app/Models/items';
import {Purchase} from 'src/app/Models/purchase';
import{Category} from 'src/app/Models/category';
import { Cart } from 'src/app/Models/cart';

//import { Buyer } from '../Models/buyer';
const Requestheaders={headers:new HttpHeaders({
  'Content-Type': 'application/json',
  'Authorization': 'Bearer '+localStorage.getItem('token')
})}
@Injectable({
  providedIn: 'root'
})
export class BuyerService {
  url:string='http://localhost:50951/Buyer/'
  constructor(private http:HttpClient) { }
  
  Getprofile(bid:number):Observable<any>
  {
    console.log(bid);
    return this.http.get<any>(this.url+'get'+'/'+bid,Requestheaders);
  }
  
  edit(item:Buyer):Observable<any>
  {
    return this.http.put<any>(this.url+'Edit',item,Requestheaders);
  }
  SearchItem(itemname:string):Observable<any>
  {
    return this.http.get<any>(this.url+'Search/'+itemname,Requestheaders)
  }
  public Getallitems():Observable<any>
  {
    return this.http.get<any>(this.url+'Getallitems',Requestheaders);
  }
  public Getcategory():Observable<Category[]>
  {
    return this.http.get<Category[]>(this.url+'Getcategory',Requestheaders);
  }
  public SearchByCategoryId(categoryid:string):Observable<any>
  {
    return this.http.get<any>(this.url+'Searchbycategoryid/'+categoryid,Requestheaders);
  }
  Buy(item:Purchase):Observable<any>
  {
    
    return this.http.post<any>(this.url+'BuyItem'+'/',item,Requestheaders);
  }
  public BuyItem(obj:Purchase):Observable<any>
{
  return this.http.post<any>(this.url+'Buyitem',obj,Requestheaders);
}
public Purchasehistory(bid:string):Observable<any>
{
  return this.http.get<any>(this.url+'History/'+bid,Requestheaders);
}
public AddtoCart(cart:Cart):Observable<any>{
  console.log("service"+cart);
  return this.http.post<any>(this.url+'Addtocart',cart,Requestheaders);
}
public GetCartItems():Observable<any>
{
  return this.http.get<any>(this.url+'Getcartitems',Requestheaders);
}
public RemoveCartItem(Cartid:string):Observable<Cart>
{
  return this.http.delete<Cart>(this.url+'Removeitem/'+Cartid,Requestheaders);
}
public GetCount(bid:string):Observable<any>
{
  return this.http.get<any>(this.url+'Getcount/'+bid,Requestheaders);
}
}
