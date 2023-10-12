import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserCredentials, UserProfile, UserRegistration } from 'src/app/models/user.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly userKey = 'currentLoggedInUser';

  setCurrentUser(id:string, email:string, name: string, isAdmin:boolean){
    const user = {
      id:id,
      email:email,
      name: name,
      isAdmin:isAdmin,
    };
    localStorage.setItem(this.userKey, JSON.stringify(user));
  }

  isLoggedIn(): boolean {
    const userString = localStorage.getItem(this.userKey);
    if(userString){
      return true;
    }
    return false;
  }

  isAdmins(): boolean {
    let user = this.getCurrentUser();
    if(user?.isAdmin ){
      return true;
    }
    return false;
  }

  getCurrentUser(): {id:string, email:string, name: string, isAdmin:boolean} | null {
    const userString = localStorage.getItem(this.userKey);
    if(userString){
      return JSON.parse(userString);
    }
    return null;
  }

  logout(){
    localStorage.removeItem(this.userKey);
  }


  baseUrl :string = environment.baseUrl + '/api/users/';

  constructor(private http: HttpClient) { }

  login(userCredentials: UserCredentials): Observable<any>{
    return this.http.post<UserProfile>(this.baseUrl + 'login',userCredentials);
  }

  signup(userRegistration: UserRegistration): Observable<any>{
    return this.http.post(this.baseUrl + 'signup',userRegistration);
  }

}
