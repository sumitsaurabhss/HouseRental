import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HouseModel, HouseCreate } from '../models/house.model';

@Injectable({
  providedIn: 'root'
})
export class HouseService {
  private baseUrl = environment.baseUrl + '/api/Houses';

  constructor(private http: HttpClient) { }

  // GET: api/houses
  getAllHouses(): Observable<HouseModel[]> {
    return this.http.get<HouseModel[]>(`${this.baseUrl}`);
  }

  // GET: api/houses/{id}
  getHouseById(id: string): Observable<HouseModel> {
    return this.http.get<HouseModel>(`${this.baseUrl}/${id}`);
  }

  // POST: api/houses/add
  addHouse(house: HouseCreate): Observable<any> {
    return this.http.post(`${this.baseUrl}/add`, house);
  }

  // PUT: api/houses/update
  updateHouse(houseId: string, rentalCost: number): Observable<any> {
    return this.http.put(`${this.baseUrl}/update/${houseId}`, rentalCost);
  }

  // DELETE: api/houses/delete/{id}
  deleteHouse(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/delete/${id}`);
  }
}
