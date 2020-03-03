import { Injectable } from '@angular/core';
import{HttpClient,HttpHeaders} from'@angular/common/http';
import {Observable} from 'rxjs';
import {Seller} from 'src/app/Models/seller';
import { Items } from 'src/app/Models/items';
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
     
        
}

      // public Delete(item:Items):Observable<any>{
      //   return this.http.delete<any>(this.url+'Delete/'+id,JSON.stringify(item),Requestheaders);}


  