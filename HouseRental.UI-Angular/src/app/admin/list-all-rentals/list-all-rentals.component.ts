import { Component } from '@angular/core';
import { RentalDetails } from 'src/app/models/rental.model';
import { RentalService } from 'src/app/services/rental.service';

@Component({
  selector: 'app-list-all-rentals',
  templateUrl: './list-all-rentals.component.html',
  styles: [
  ]
})
export class ListAllRentalsComponent {
  rentalDetailsList: RentalDetails[] = [];

  deleteRental(rentalId: string) {
    const confirmDelete = window.confirm('Are you sure you want to delete this rental?');
    if (confirmDelete) {
      // Find and remove the rental from the list by its ID
      this.rentalService.validateReturn(rentalId)
      .subscribe({
        next:(response) =>{
          this.getAllAgreements();
          console.log(response);
        },
        error:(error) => {
          console.log(error);
        }
      });
    }
  }

  constructor(private rentalService: RentalService){}

  ngOnInit(): void {
    this.getAllAgreements();
  }

  getAllAgreements()
  {
    this.rentalService.getAllRentals()
    .subscribe({
      next :(response) =>{
        console.log(response);
        this.rentalDetailsList = response;
      }
    })
  }

  validateReturn(rentalId: string)
  {
    console.log(rentalId);
    this.rentalService.validateReturn(rentalId)
    .subscribe({
      next:(response) =>{
        this.getAllAgreements();
        console.log(response);
      },
      error:(error) => {
        console.log(error);
      }
    });
  }

  editForm: any = {
    isFormActive: false,
    id: '',
    duration: 0
  }
  setEditForm(rentalId: string) {
    this.resetForm(this.editForm.id);
    this.editForm.id = rentalId;
    this.editForm.isFormActive = true;
    this.editForm.duration = 0;
    console.log(this.editForm);
  }

  resetForm(rentalId: string) {
    this.editForm.id = rentalId;
    this.editForm.isFormActive = false;
  }

  save() {
    console.log(this.editForm);
    if(this.editForm.duration < 1) {
      alert("Please enter positive number in rental duration.");
    }
    else {
      this.rentalService.updateRental(this.editForm.id, this.editForm.duration)
      .subscribe({
        next :(response) =>{
          this.getAllAgreements();
          this.resetForm(this.editForm.id);
        }
      });
    }
  }
}