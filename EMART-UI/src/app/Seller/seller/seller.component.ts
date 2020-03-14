import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-seller',
  templateUrl: './seller.component.html',
  styleUrls: ['./seller.component.css']
})
export class SellerComponent implements OnInit {

  username:string;
constructor(private route:Router) {

  console.log(localStorage.getItem('sid'));
  

}

ngOnInit() {
}
public Logout()
{
  //clear session data
  sessionStorage.clear();
  this.route.navigate(['login']);
  //this.route.navigateByUrl('login')
}

}
