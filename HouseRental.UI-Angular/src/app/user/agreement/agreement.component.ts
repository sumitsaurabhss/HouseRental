import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RentalAgreement, RentalCreate } from 'src/app/models/rental.model';
import { AuthService } from 'src/app/services/auth.service';
import { RentalService } from 'src/app/services/rental.service';

@Component({
  selector: 'app-agreement',
  templateUrl: './agreement.component.html',
  styles: [
  ]
})
export class AgreementComponent {
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
  rentalCreate: RentalCreate = {
    houseId: '',
    userId: '',
    totalRentalCost: 0,
    durationInMonths: 0
  }


 

  
  ngOnInit(): void {
    // Retrieve the rental agreement data from the router's state
    this.route.paramMap.subscribe(params => {
      const rentalAgreement = history.state?.rentalAgreement;
      if (rentalAgreement) {
        this.rentalAgreement = rentalAgreement;
      }
    });
    console.log(this.rentalAgreement);
  }
  currentLoggedInUserName:string = '';
  currentLoggedInUserId:string = '';
  isAdmin=false;

  loggedUser : {id:string, email:string, name: string, isAdmin:boolean} | null;

  constructor(private userService: AuthService, private rentalService: RentalService,private route: ActivatedRoute, private router: Router)
  {
    this.loggedUser = this.userService.getCurrentUser();
    this.currentLoggedInUserName = this.loggedUser?.name!;
    this.currentLoggedInUserId = this.loggedUser?.id!;

    this.isAdmin = this.loggedUser?.isAdmin!;
  }

  onDurationChange() {
    this.rentalAgreement.totalRentalCost = this.rentalAgreement.rentalDurationInMonths * this.rentalAgreement.rentalCostPerMonth;
  }

  continue() {

    if(this.loggedUser == null)
    {
      alert("You need to login first.");
      this.router.navigate(["login"]);
    }
    else if(this.rentalAgreement.rentalDurationInMonths < 1) {
      alert("Please enter positive number in rental duration.");
    }

    else {
      const confirmAgreement = window.confirm('Are you sure you want to accept this rental agreement?');
      if (confirmAgreement) {
        this.rentalCreate = {
          houseId: this.rentalAgreement.houseId,
          userId: this.rentalAgreement.userId,
          totalRentalCost: this.rentalAgreement.totalRentalCost,
          durationInMonths: this.rentalAgreement.rentalDurationInMonths
        };
        console.log(this.rentalCreate);
      
        this.rentalService.addRental(this.rentalCreate)
        .subscribe({
          next:(apiResponse) => {
            console.log(apiResponse);
    
            alert("Your booking has confirmed for "+ this.rentalCreate.durationInMonths + " months starting from next month.");
            this.router.navigate(['rentals']);
          }
        })
        
      }
    }
  }
}