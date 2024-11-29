import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Estate } from '../models/estate.model';

@Injectable({
  providedIn: 'root'
})
export class EstateService {

  private apiURL = 'http://localhost:5045/api/estates';

  constructor( private http: HttpClient) { }

  public getEstates(): Observable<Estate[]> {
    return this.http.get<Estate[]>(this.apiURL);
  }
  
  public createEstate(estate: Estate): Observable<Estate> {
    return this.http.post<Estate>(this.apiURL, estate);
  }
}
