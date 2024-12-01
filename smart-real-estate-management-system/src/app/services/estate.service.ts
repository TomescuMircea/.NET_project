 import { Injectable } from '@angular/core';
 import { HttpClient } from '@angular/common/http';
 import { Observable } from 'rxjs';
 import { Estate } from '../models/estate.model';

@Injectable({
  providedIn: 'root'
})
export class EstateService {
  private apiURL = 'http://localhost:5045/api/estates';

  constructor(private http: HttpClient) {}

  public getPaginatedEstates(pageNumber: number, pageSize: number): Observable<Estate> {
    const paginatedUrl = `${this.apiURL}/paginated?page=${pageNumber}&pageSize=${pageSize}`;
    return this.http.get<Estate>(paginatedUrl);

  }

  public createEstate(estate: Estate): Observable<Estate> {
    return this.http.post<Estate>(this.apiURL, estate);
  }

  public updateEstate(estate: Estate): Observable<Estate> {
    return this.http.put<Estate>(`${this.apiURL}/${estate.id}`, estate);
  }

  public getEstateById(id: string): Observable<Estate> {
    return this.http.get<Estate>(`${this.apiURL}/${id}`);
  }

  public deleteEstate(id: string): Observable<any> {
    return this.http.delete(`${this.apiURL}/${id}`);
  }
}
