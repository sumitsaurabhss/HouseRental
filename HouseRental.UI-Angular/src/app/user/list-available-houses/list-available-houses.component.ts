import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HouseModel } from 'src/app/models/house.model';
import { RentalAgreement } from 'src/app/models/rental.model';
import { AuthService } from 'src/app/services/auth.service';
import { HouseService } from 'src/app/services/house.service';

@Component({
  selector: 'app-list-available-houses',
  templateUrl: './list-available-houses.component.html',
  styles: [
  ]
})
export class ListAvailableHousesComponent {
  houses: HouseModel[] = [];
  
  currentLoggedInUserName:string = '';
  currentLoggedInUserId:string = '';
  isAdmin=false;

  loggedUser : {id:string, email:string, name: string, isAdmin:boolean} | null;

  constructor(private userService: AuthService, private houseService: HouseService, private router: Router)
  {
    this.loggedUser = this.userService.getCurrentUser();
    this.currentLoggedInUserName = this.loggedUser?.name!;
    this.currentLoggedInUserId = this.loggedUser?.id!;

    this.isAdmin = this.loggedUser?.isAdmin!;
  }

  typeFilter: string = '';
  addressFilter: string = '';
  rentalCostFilter: number | undefined = undefined;

  filteredHouses: HouseModel[] = [];

  filterHouses(): void {
    this.filteredHouses = this.houses.filter(house =>
      (this.typeFilter === '' || house.type.toLowerCase().includes(this.typeFilter.toLowerCase())) &&
      (this.addressFilter === '' || house.address.toLowerCase().includes(this.addressFilter.toLowerCase())) &&
      (this.rentalCostFilter === undefined || this.rentalCostFilter === null || house.rentalCostPerMonth <= this.rentalCostFilter)
    );

    // If no filters are set, display all houses
    if (this.typeFilter === '' && this.addressFilter === '' && (this.rentalCostFilter === undefined || this.rentalCostFilter === null)) {
      this.filteredHouses = this.houses;
    }
  }

  ngOnInit(){
    this.getAllhouses();
  }
  
  getAllhouses(){
     this.houseService.getAllHouses()
    .subscribe({
      next:(houses) => {
        this.houses = houses;
        this.filteredHouses = houses;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  // Create a rental agreement object
  rentalAgreement: RentalAgreement = {
    houseId: '',
    type: '',
    address: '',
    rentalCostPerMonth: 0,
    rentalDurationInMonths: 0,
    totalRentalCost: 0,
    isReturned: false,
    userId: ''
  };

  selectedHouse: HouseModel | null = null;
  rentalDuration: number = 0;
  
  selectedIndex = -1;

  selectHouse(index: number) {
    this.cancelSelection();
    this.selectedIndex = index;
    this.selectedHouse = { ...this.filteredHouses[index] }; // Clone the selected house
  }

  cancelSelection() {
    this.selectedIndex = -1;
    this.selectedHouse = null; // Clear the edited house
  }

  generateRentalAgreement(): void {

    if(this.loggedUser == null)
    {
      alert("You need to login first.");
      this.router.navigate(["login"]);
    }
    else if(this.rentalDuration < 1) {
      alert("Please enter positive number in rental duration.");
    }
    else if (this.selectedHouse && this.rentalDuration) {
      const totalRentalCost = this.selectedHouse.rentalCostPerMonth * this.rentalDuration;
      // add the user's name from user authentication system
      
      this.rentalAgreement.houseId = this.selectedHouse.id;
      this.rentalAgreement.type = this.selectedHouse.type;
      this.rentalAgreement.address = this.selectedHouse.address;
      this.rentalAgreement.rentalCostPerMonth = this.selectedHouse.rentalCostPerMonth;
      this.rentalAgreement.rentalDurationInMonths = this.rentalDuration;
      this.rentalAgreement.totalRentalCost = totalRentalCost;
      this.rentalAgreement.isReturned = false;
      this.rentalAgreement.userId = this.currentLoggedInUserId;

      console.log(this.rentalAgreement);

      // Pass the rental agreement data as a route data parameter
      this.router.navigate(['houses/rent'], { state: { rentalAgreement: this.rentalAgreement } });
      
      this.selectedIndex = -1; // Hide the row
      this.selectedHouse = null; // Clear the selected house

    }
  }
}