import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-buyer',
   templateUrl: './buyer.component.html',
  styleUrls: ['./buyer.component.css']
})
export class BuyerComponent implements OnInit {
username:string;
constructor(private route:Router) {

}

ngOnInit() {
}
public Logout()
{
  
  sessionStorage.clear();
  //this.route.navigate(['']);
  this.route.navigateByUrl('#home')
}

}