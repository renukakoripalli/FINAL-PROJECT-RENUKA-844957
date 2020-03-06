import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Buyer } from 'src/app/Models/buyer';
import { Items } from 'src/app/Models/items';
//import { Buyer } from '../Models/buyer';
const Requestheaders={headers:new HttpHeaders({
  'Content-Type': 'application/json',
  'Authorization': 'Bearer'+localStorage.getItem('token')
})}
@Injectable({
  providedIn: 'root'
})
export class BuyerService {
  url:string='http://localhost:50951/Buyer/'
  constructor(private http:HttpClient) { }
  
  Myprofile(bid:number):Observable<any>
  {
    return this.http.get<any>(this.url+'GetProfile'+'/'+bid,Requestheaders);
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
}