import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserRegistration } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: [
  ]
})
export class RegisterComponent {
  userRegistration: UserRegistration = {
    name: '',
    email: '',
    password: ''
  };

  constructor(private userService: AuthService, private router: Router) {}

  signup() {
    //if(this.form.valid)
    this.userService.signup(this.userRegistration)
    .subscribe({
      next:(response) => {
        if(response.message !== null)
        {
          console.log(response);
          alert('You are registered.');
          this.router.navigate(['login']);
        }
        else  alert("You could not be registered.");
      },
      error:(error) => {
        console.log(error);
      }
    });
  }

}
