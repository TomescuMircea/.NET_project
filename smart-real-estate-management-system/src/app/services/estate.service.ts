import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Estate } from '../models/estate.model';

@Injectable({
  providedIn: 'root'
})
export class EstateService {

  private apiURL = 'http://localhost:5045/api/estates/paginated';

  constructor(private http: HttpClient) { }

  public getEstates(pageNumber: number, pageSize: number): Observable<Estate[]> {
    const paginatedUrl = `${this.apiURL}?page=${pageNumber}&pageSize=${pageSize}`;
    return this.http.get<Estate[]>(paginatedUrl);
  }
  
  public createEstate(estate: Estate): Observable<Estate> {
    return this.http.post<Estate>(this.apiURL, estate);
  }

  public updateEstate(estate: Estate): Observable<Estate> {
    return this.http.put<Estate>(this.apiURL + '/' + estate.id, estate);
  }

  getEstateById(id: string): Observable<Estate> {
    return this.http.get<Estate>(this.apiURL + '/' + id);
  }
}
