import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styles: [
  ]
})
export class NavbarComponent {
  currentLoggedInUserName:string = '';
  currentLoggedInUserId:string = '';
  isAdmin=false;

  loggedUser : {id:string, email:string, name: string, isAdmin:boolean} | null;

  constructor(private authService: AuthService,private route: ActivatedRoute, private router: Router)
  {
    this.loggedUser = this.authService.getCurrentUser();
    this.currentLoggedInUserName = this.loggedUser?.name!;
    this.currentLoggedInUserId = this.loggedUser?.id!;

    this.isAdmin = this.loggedUser?.isAdmin!;
  }
  ngOnInit(): void {
    
  }

  userLogOut()
  {
    this.authService.logout();
    this.currentLoggedInUserName= '';
    this.router.navigate(['nav']).then(() => {
      window.location.reload();
    });
    this.router.navigate([""]);
  }
}