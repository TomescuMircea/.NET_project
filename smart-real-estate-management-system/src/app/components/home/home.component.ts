import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  constructor(private readonly router: Router) { }

  navigateToEstateList(): void {
    this.router.navigate(['estates/paginated']);
   }

   navigateToLogin(): void {
    this.router.navigate(['login']);
   }

   navigateToRegister(): void {
    this.router.navigate(['register']);
   }
}
