import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from './Account/home/home.component';
import { AddItemsComponent } from './Seller/add-items/add-items.component';
import { SellerComponent } from './Seller/seller/seller.component';
import { ViewItemsComponent } from './Seller/view-items/view-items.component';
import { ViewReportsComponent } from './Seller/view-reports/view-reports.component';
import { ViewProfileComponent } from './Seller/view-profile/view-profile.component';
import { BuyerComponent } from './Buyer/buyer/buyer.component';
import { SearchComponent } from './Buyer/search/search.component';
import { ViewcartComponent } from './Buyer/viewcart/viewcart.component';
import { PurchaseHistoryComponent } from './Buyer/purchase-history/purchase-history.component';
import { BuyproductComponent } from './Buyer/buyproduct/buyproduct.component';
import { AdminComponent } from './Admin/admin/admin.component';
import { BlockUnblockBuyerComponent } from './Admin/block-unblock-buyer/block-unblock-buyer.component';
import { BlockUnblockSellerComponent } from './Admin/block-unblock-seller/block-unblock-seller.component';
import { AddCategoryComponent } from './Admin/add-category/add-category.component';
import { AddSubcategoryComponent } from './Admin/add-subcategory/add-subcategory.component';
import { DailyReportsComponent } from './Admin/daily-reports/daily-reports.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterSellerComponent } from './Account/register-seller/register-seller.component';
import { RegisterBuyerComponent } from './Account/register-buyer/register-buyer.component';
import { ContactComponent } from './Account/contact/contact.component';



const routes: Routes = [
  
  {path:'seller',component:SellerComponent,children:[
    {path:'add-items',component:AddItemsComponent},
    {path:'view-items',component:ViewItemsComponent},
    {path:'view-reports',component:ViewReportsComponent},
    {path:'view-profile',component:ViewProfileComponent}
  ]},
  {path:'buyer',component:BuyerComponent,children:[
    {path:'search',component:SearchComponent},
    {path:'viewcart',component:ViewcartComponent},
    {path:'purchase-history',component:PurchaseHistoryComponent},
    {path:'buyproduct',component:BuyproductComponent},
    {path:'viewprofile',component:ViewProfileComponent}
  ]},
  {path:'admin',component:AdminComponent,children:[
    {path:'block-unblock-buyer',component:BlockUnblockBuyerComponent},
    {path:'block-unblock-seller',component:BlockUnblockSellerComponent},
    {path:'add-category',component:AddCategoryComponent},
    {path:'add-subcategory',component:AddSubcategoryComponent},
    {path:'daily-report',component:DailyReportsComponent}
  ]},
  
  {path:'home',component:HomeComponent,children:[
   {path:'contact',component:ContactComponent},
     {path:'login',component:LoginComponent},
    {path:'register-seller',component:RegisterSellerComponent},
     {path:'register-buyer',component:RegisterBuyerComponent}
  
    ]}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
