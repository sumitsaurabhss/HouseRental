import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserCredentials } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent {
  userCredentials: UserCredentials = {
    email: '',
    password: ''
  };

  currentLoggedInUserName:string = '';
  currentLoggedInUserId:string = '';
  isAdmin=false;

  loggedUser : {id:string, email:string, name: string, isAdmin:boolean} | null;
  constructor(private userService: AuthService, private router: Router)
   { 
    this.loggedUser = this.userService.getCurrentUser();
    this.currentLoggedInUserName = this.loggedUser?.name!;
    this.currentLoggedInUserId = this.loggedUser?.id!;

    this.isAdmin = this.loggedUser?.isAdmin!;
   }

   ngOnInit(): void {
    if(this.currentLoggedInUserName)
    {
      this.router.navigate(['cars']);
    }
   }


  userLogin() {
    //temporarily
    if(this.userCredentials.email && this.userCredentials.password){
      this.userService.login(this.userCredentials)
      .subscribe({
        next:(response) => {
          console.log(response);
          if(response.message !== null)
          {
             console.log("Success Login");
            this.userService.setCurrentUser(response.id,this.userCredentials.email, response.name,response.isAdmin,);
             console.log(response);

            this.router.navigate(['nav']).then(() => {
              window.location.reload();
            });

            if(response.isAdmin === true)
            {
               this.router.navigate(['admin/rentals']);
            }
            else {
              const returnUrl = this.router.routerState.snapshot.root.queryParams['returnUrl'] || '/';
              this.router.navigateByUrl(returnUrl);
            }
            
          }
          else  alert("Invalid Credentials");
        },
        error:(error) => {
          alert("Invalid Credentials");
          // console.log("Invalid Credentials");
        }
      })
      
    }
  }

}