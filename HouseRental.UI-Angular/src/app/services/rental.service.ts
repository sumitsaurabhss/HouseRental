import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { RentalDetails, RentalCreate } from '../models/rental.model';

@Injectable({
  providedIn: 'root'
})
export class RentalService {
  private baseUrl = environment.baseUrl + '/api/rentals';

  constructor(private http: HttpClient) { }

  // GET: api/rentals/all
  getAllRentals(): Observable<RentalDetails[]> {
    return this.http.get<RentalDetails[]>(`${this.baseUrl}/all`);
  }

  // GET: api/rentals?userId={userId}
  getAllRentalsByUserId(userId: string): Observable<RentalDetails[]> {
    return this.http.get<RentalDetails[]>(`${this.baseUrl}/all/${userId}`);
  }

  // GET: api/rentals/{id}
  getRentalById(id: string): Observable<RentalDetails> {
    return this.http.get<RentalDetails>(`${this.baseUrl}/${id}`);
  }

  // POST: api/rentals/add
  addRental(rental: RentalCreate): Observable<any> {
    return this.http.post(`${this.baseUrl}/add`, rental);
  }

  // PUT: api/rentals/update
  updateRental(rentalId: string, duration: number): Observable<any> {
    return this.http.put(`${this.baseUrl}/update/${rentalId}`, duration);
  }

  // PATCH: api/rentals/return/{id}
  requestForReturn(rentalId: string, rentalDetail: RentalDetails): Observable<any> {
    return this.http.patch(`${this.baseUrl}/return/${rentalId}`, rentalDetail);
  }

  // DELETE: api/rentals/validate/{id}
  validateReturn(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/validate/${id}`);
  }
}
