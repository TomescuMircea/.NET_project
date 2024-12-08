 import { Injectable } from '@angular/core';
 import { HttpClient } from '@angular/common/http';
 import { Observable } from 'rxjs';
 import { Estate } from '../models/estate.model';

@Injectable({
  providedIn: 'root'
})
export class EstateService {
  private readonly apiURL = 'http://localhost:5045/api/estates';

  constructor(private readonly http: HttpClient) {}

  public getPaginatedEstates(pageNumber: number, pageSize: number): Observable<Estate[]> {
    const paginatedUrl = `${this.apiURL}/paginated?page=${pageNumber}&pageSize=${pageSize}`;
    return this.http.get<Estate[]>(paginatedUrl);
  }

  // public createEstate(estate: Estate): Observable<Estate> {
    
  //   return this.http.post<Estate>(this.apiURL, estate);
  // }

  public createEstate(estate: Estate): Observable<Estate> {
    // Obține token-ul din localStorage
    const token = localStorage.getItem('token');
    console.log("Token1", token);
  
    // Creează anteturile și adaugă token-ul
    const headers = token
      ? { Authorization: `Bearer ${token}` }
      : undefined;
  
    // Trimite cererea POST cu antetul personalizat
    return this.http.post<Estate>(this.apiURL, estate, { headers });
  }
  
  public updateEstate(estate: Estate): Observable<Estate> {
    // Obține token-ul din localStorage
    const token = localStorage.getItem('token');
    console.log("Token", token);
  
    // Creează anteturile și adaugă token-ul
    const headers = token
      ? { Authorization: `Bearer ${token}` }
      : undefined;

    return this.http.put<Estate>(`${this.apiURL}/${estate.id}`, estate, { headers });
  }

  public getEstateById(id: string): Observable<Estate> {
    return this.http.get<Estate>(`${this.apiURL}/${id}`);
  }

  public deleteEstate(id: string): Observable<any> {
    // Obține token-ul din localStorage
    const token = localStorage.getItem('token');
    console.log("Token", token);
  
    // Creează anteturile și adaugă token-ul
    const headers = token
      ? { Authorization: `Bearer ${token}` }
      : undefined;

    return this.http.delete(`${this.apiURL}/${id}`, { headers });
  }
}
