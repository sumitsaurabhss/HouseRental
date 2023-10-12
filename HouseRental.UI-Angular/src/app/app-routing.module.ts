import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListAvailableHousesComponent } from './user/list-available-houses/list-available-houses.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { AgreementComponent } from './user/agreement/agreement.component';
import { authGuard } from './authguard/auth.guard';
import { ListUserRentalsComponent } from './user/list-user-rentals/list-user-rentals.component';
import { ListAllRentalsComponent } from './admin/list-all-rentals/list-all-rentals.component';
import { adminGuard } from './authguard/admin.guard';
import { ListAllHousesComponent } from './admin/list-all-houses/list-all-houses.component';
import { AddHouseComponent } from './admin/add-house/add-house.component';
import { LoginComponent } from './authentication/login/login.component';
import { RegisterComponent } from './authentication/register/register.component';

const routes: Routes = [
  { path: '', component: ListAvailableHousesComponent },
  { path: 'houses', component: ListAvailableHousesComponent },
  { path: 'nav', component: NavbarComponent },
  { path: 'houses/rent', component: AgreementComponent, data: { rentalAgreement: {} }, canActivate:[authGuard]},
  { path: 'rentals', component: ListUserRentalsComponent, canActivate:[authGuard] },
  { path: 'admin', component: ListAllRentalsComponent , canActivate:[adminGuard] },
  { path: 'admin/rentals', component: ListAllRentalsComponent , canActivate:[adminGuard] },
  { path: 'admin/houses', component: ListAllHousesComponent , canActivate:[adminGuard] },
  // { path: 'admin/rentals/edit/:id', component: EditRentalComponent, canActivate:[adminGuard] },
  { path: 'admin/houses/add', component: AddHouseComponent, canActivate:[adminGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
