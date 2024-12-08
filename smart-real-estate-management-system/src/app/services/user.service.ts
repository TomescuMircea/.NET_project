import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { User } from '../models/user.model';
import {jwtDecode} from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly apiURL = 'http://localhost:5045/api/Auth';

  isUserLoggedIn: boolean = false;
  public userName: string | null = null;
  public userId: string = '';

  constructor(private readonly http: HttpClient) {
    this.initializeUserFromToken();
  }

  // Inițializează userName și userId din localStorage
  private initializeUserFromToken(): void {
    const token = localStorage.getItem('token');
    if (token) {
      const decodedToken = jwtDecode<any>(token);
      console.log(decodedToken);
      this.userName = decodedToken['unique_name'] || null; // Presupunem că numele utilizatorului este salvat în `unique_name`
      this.userId = decodedToken['nameid'] || ''; // Presupunem că UserId este salvat în `nameid`
    }
  }

  public register(user: User): Observable<User> {
    return this.http.post<User>(`${this.apiURL}/register`, user);
  }

  public login(user: User): Observable<any> {
    return this.http.post<any>(`${this.apiURL}/login`, user).pipe(
      tap((response: any) => {
        const token = response.token;
        console.log('Service token: ', token);
        localStorage.setItem('token', token);

        // Decodează token-ul pentru a extrage numele
        const decodedToken = jwtDecode<any>(token);
        this.userName = decodedToken['unique_name'] || null;
        this.userId = decodedToken['nameid'] || '';
        console.log('Service username: ', this.userName);

        if (this.userName !== null) {
          localStorage.setItem('userName', this.userName);
        }
      })
    );
  }

  public logout(): void {
    localStorage.removeItem('token');
    this.userName = null;
    this.userId = '';
    this.isUserLoggedIn = false;
  }

  public isLoggedIn(): boolean {
    const token = localStorage.getItem('token');
    this.isUserLoggedIn = !!token;
    return this.isUserLoggedIn;
  }

  public getUserName(): string | null {
    return this.userName;
  }

  public getUserId(): string {
    return this.userId;
  }
}
