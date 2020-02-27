import { Injectable } from '@angular/core';
import{HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Buyer } from 'src/app/Models/buyer';
import { Seller } from 'src/app/Models/seller';
import { stringify } from 'querystring';
const Requestheaders={headers:new HttpHeaders({
  'content-type':'application/json'})

}
@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  url:string='http://localhost:50951/Account/'
  JSON: any;
    constructor(private http:HttpClient) {}
    addBuyer(item:Buyer):Observable<any>
    {
      return this.http.post<any>(this.url+'addb',JSON.stringify(item),Requestheaders);
    }
    addSeller(seller:Seller):Observable<any>
    {
      return this.http.post<any>(this.url+'adds',JSON.stringify(seller),Requestheaders);
    }
    
  }