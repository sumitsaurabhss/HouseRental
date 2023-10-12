import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RentalDetails } from 'src/app/models/rental.model';
import { AuthService } from 'src/app/services/auth.service';
import { RentalService } from 'src/app/services/rental.service';

@Component({
  selector: 'app-list-user-rentals',
  templateUrl: './list-user-rentals.component.html',
  styles: [
  ]
})
export class ListUserRentalsComponent {
  rentalDetailsList: RentalDetails[] = [];
  currentLoggedInUserName:string = '';
  currentLoggedInUserId:string = '';
  isAdmin=false;

  loggedUser : {id:string, email:string, name: string, isAdmin:boolean} | null;

  constructor(private userService: AuthService, private rentalService: RentalService, private router: Router)
  {
    this.loggedUser = this.userService.getCurrentUser();
    this.currentLoggedInUserName = this.loggedUser?.name!;
    this.currentLoggedInUserId = this.loggedUser?.id!;

    this.isAdmin = this.loggedUser?.isAdmin!;
  }


  ngOnInit(): void {
    this.getAllAgreements();
  }

  getAllAgreements()
  {
    this.rentalService.getAllRentalsByUserId(this.currentLoggedInUserId)
    .subscribe({
      next :(response) =>{
        console.log(response);
        this.rentalDetailsList = response;
      }
    })
  }

  //Add request for return
  return(rentalDetail: RentalDetails) {
    this.rentalService.requestForReturn(rentalDetail.id, rentalDetail)
    .subscribe({
      next :(response) =>{
        this.getAllAgreements();
      }
    })
  }

  //userIdToFilter: string = '123'; // Set the userId to filter

  //filteredRentalDetails: RentalDetails[] = [];

  // ngOnInit(): void {
  //   // Filter rental details based on the userId
  //   this.filteredRentalDetails = this.rentalDetailsList.filter(
  //     (rentalDetail) => rentalDetail.userId === this.userIdToFilter
  //   );
  // }
}