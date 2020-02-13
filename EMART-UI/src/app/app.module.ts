import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import{BuyerComponent}from './Buyer/buyer/buyer.component';
import { SellerComponent } from './Seller/seller/seller.component';
//import { AccountComponent } from './account/account/account.component';
import { AdminComponent } from './Admin/admin/admin.component';
import { SearchComponent } from './Buyer/search/search.component';
import { ViewcartComponent } from './Buyer/viewcart/viewcart.component';
import { PurchaseHistoryComponent } from './Buyer/purchase-history/purchase-history.component';
import { BuyproductComponent } from './Buyer/buyproduct/buyproduct.component';
import { ViewprofileComponent } from './Buyer/viewprofile/viewprofile.component';
import { AddItemsComponent } from './Seller/add-items/add-items.component';
import { ViewItemsComponent } from './Seller/view-items/view-items.component';
import { ViewReportsComponent } from './Seller/view-reports/view-reports.component';
import { ViewProfileComponent } from './Seller/view-profile/view-profile.component';
import { BlockUnblockBuyerComponent } from './Admin/block-unblock-buyer/block-unblock-buyer.component';
import { BlockUnblockSellerComponent } from './Admin/block-unblock-seller/block-unblock-seller.component';
import { AddCategoryComponent } from './Admin/add-category/add-category.component';
import { AddSubcategoryComponent } from './Admin/add-subcategory/add-subcategory.component';
import { DailyReportsComponent } from './Admin/daily-reports/daily-reports.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterSellerComponent } from './Account/register-seller/register-seller.component';
import { RegisterBuyerComponent } from './Account/register-buyer/register-buyer.component';

@NgModule({
  declarations: [
    AppComponent,
    BuyerComponent,
    SellerComponent,
    
    AdminComponent,
    SearchComponent,
    ViewcartComponent,
    PurchaseHistoryComponent,
    BuyproductComponent,
    ViewprofileComponent,
    AddItemsComponent,
    ViewItemsComponent,
    ViewReportsComponent,
    ViewProfileComponent,
    BlockUnblockBuyerComponent,
    BlockUnblockSellerComponent,
    AddCategoryComponent,
    AddSubcategoryComponent,
    DailyReportsComponent,
    LoginComponent,
    RegisterSellerComponent,
    RegisterBuyerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
