import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  constructor(private readonly userService: UserService, private readonly router: Router) { }

  navigateToEstateList(): void {
    this.router.navigate(['estates/filter/paginated']);
   }

   navigateToLogin(): void {
    this.router.navigate(['login']);
   }

   navigateToRegister(): void {
    this.router.navigate(['register']);
   }

   isLogged(): boolean{
    if(this.userService.isLoggedIn())
      return true;
    return false;
   }

   logout(): void{
    this.userService.logout()
    this.router.navigate(["/login"])
   }

   public getUserName(): string | null {
    
    return this.userService.getUserName();
  }
}
