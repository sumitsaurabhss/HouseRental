import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HouseCreate } from 'src/app/models/house.model';
import { AuthService } from 'src/app/services/auth.service';
import { HouseService } from 'src/app/services/house.service';

@Component({
  selector: 'app-add-house',
  templateUrl: './add-house.component.html',
  styles: [
  ]
})
export class AddHouseComponent {
  houseCreate: HouseCreate = {
    type: '',
    address: '',
    rentalCostPerMonth: 0
  };
  
  currentLoggedInUserName:string = '';
  currentLoggedInUserId:string = '';
  isAdmin=false;

  loggedUser : {id:string, email:string, name: string, isAdmin:boolean} | null;

  constructor(private houseService: HouseService, private userService: AuthService, private router: Router){
    this.loggedUser = this.userService.getCurrentUser();
    this.currentLoggedInUserName = this.loggedUser?.name!;
    this.currentLoggedInUserId = this.loggedUser?.id!;

    this.isAdmin = this.loggedUser?.isAdmin!;
  }

  addHouse()
  {
    if(this.houseCreate.rentalCostPerMonth < 1) {
      alert("Please enter positive number in rental cost.");
    }
    else {
      this.houseService.addHouse(this.houseCreate)
      .subscribe({
        next:(response) => {
          console.log(response);
          alert('House Added Successfully');
          this.router.navigate(['admin/houses']);
        },
        error:(error) => {
          console.log(error);
        }
      });
    }
  }

}
