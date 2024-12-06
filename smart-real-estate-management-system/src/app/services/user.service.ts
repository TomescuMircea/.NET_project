import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly apiURL = 'http://localhost:5045/api/Auth';

  constructor(private readonly http: HttpClient) {}

  public register(user: User): Observable<User> {
    return this.http.post<User>(`${this.apiURL}/register`, user);
  }

  public login(user: User): Observable<User> {
    return this.http.post<User>(`${this.apiURL}/login`, user);
  }
}
