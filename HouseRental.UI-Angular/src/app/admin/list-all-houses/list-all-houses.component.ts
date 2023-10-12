import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HouseModel } from 'src/app/models/house.model';
import { AuthService } from 'src/app/services/auth.service';
import { HouseService } from 'src/app/services/house.service';

@Component({
  selector: 'app-list-all-houses',
  templateUrl: './list-all-houses.component.html',
  styles: [
  ]
})
export class ListAllHousesComponent {
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
    this.getAllHouses();
  }
  
  getAllHouses(){
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

  deleteHouse(houseId: string) {
    const confirmDelete = window.confirm('Are you sure you want to remove this house?');
    if (confirmDelete) {
      // Find and remove the house from the list by its ID
      this.houseService.deleteHouse(houseId)
      .subscribe({
        next:(response) =>{
          this.getAllHouses();
          console.log(response);
        },
        error:(error) => {
          console.log(error);
        }
      });
    }
  }

  editForm: any = {
    isFormActive: false,
    id: '',
    rentalCost: 0
  }
  setEditForm(houseId: string) {
    this.resetForm(this.editForm.id);
    this.editForm.id = houseId;
    this.editForm.isFormActive = true;
    this.editForm.rentalCost = 0;
    console.log(this.editForm);
  }

  resetForm(houseId: string) {
    this.editForm.id = houseId;
    this.editForm.isFormActive = false;
  }

  save() {
    console.log(this.editForm);
    if(this.editForm.rentalCost < 1) {
      alert("Please enter positive number in rental cost.");
    }
    else {
      this.houseService.updateHouse(this.editForm.id, this.editForm.rentalCost)
      .subscribe({
        next :(response) =>{
          this.getAllHouses();
          this.resetForm(this.editForm.id);
        }
      });
    }
  }
}