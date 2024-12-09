import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Estate } from '../models/estate.model';


@Injectable({
  providedIn: 'root'
})
export class EstateService {
  private readonly apiURL = 'https://smart-real-estate-management-227505df1e15.herokuapp.com/api/estates';

  constructor(private readonly http: HttpClient) {}

  getPaginatedEstates(name: string, address: string, type: string, price: number, size: number, page: number, pageSize: number): Observable<any> {
    let params = new HttpParams()
      .set('name', name)
      .set('address', address)
      .set('type', type)
      .set('price', price.toString())
      .set('size', size.toString())
      .set('page', page.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<any>(`${this.apiURL}/filter/paginated`, { params });
  }


  public getPaginatedFilterEstates(pageNumber: number, pageSize: number): Observable<Estate[]> {
    const paginatedUrl = `${this.apiURL}/filter/paginated?page=${pageNumber}&pageSize=${pageSize}`;
    // filter/paginated?type=1&page=1&pageSize=5
    return this.http.get<Estate[]>(paginatedUrl);
  }


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
