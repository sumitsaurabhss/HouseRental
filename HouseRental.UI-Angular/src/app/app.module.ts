import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { AddHouseComponent } from './admin/add-house/add-house.component';
import { ListAllHousesComponent } from './admin/list-all-houses/list-all-houses.component';
import { ListAllRentalsComponent } from './admin/list-all-rentals/list-all-rentals.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { FooterComponent } from './layout/footer/footer.component';
import { AgreementComponent } from './user/agreement/agreement.component';
import { ListUserRentalsComponent } from './user/list-user-rentals/list-user-rentals.component';
import { ListAvailableHousesComponent } from './user/list-available-houses/list-available-houses.component';
import { RegisterComponent } from './authentication/register/register.component';
import { LoginComponent } from './authentication/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    AddHouseComponent,
    ListAllHousesComponent,
    ListAllRentalsComponent,
    NavbarComponent,
    FooterComponent,
    AgreementComponent,
    ListUserRentalsComponent,
    ListAvailableHousesComponent,
    RegisterComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
