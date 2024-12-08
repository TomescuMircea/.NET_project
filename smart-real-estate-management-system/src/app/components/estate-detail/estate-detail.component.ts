import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EstateService } from '../../services/estate.service';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-estate-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './estate-detail.component.html',
  styleUrl: './estate-detail.component.css'
})
export class EstateDetailComponent implements OnInit {
  estate: any;
  errorMessage: string = '';

  constructor(
    private readonly route: ActivatedRoute,
    private readonly estateService: EstateService,
    private readonly router: Router,
    private readonly userService: UserService
  ) {}

  ngOnInit(): void {
    const estateId = this.route.snapshot.paramMap.get('id');
    if (estateId) {
      this.estateService.getEstateById(estateId).subscribe(data => {
        this.estate = data;
      });
    }
  }

  onDelete(id: string): void {
    const userId=this.userService.getUserId();

    if (!userId) {
      this.errorMessage = 'You must log in.';
      console.error(this.errorMessage);
      return;
    }
    else if (userId!=this.estate.userId) {
      this.errorMessage = 'You are not authorized to delete this estate.';
      console.error(this.errorMessage);
      return;
    }

    this.estateService.deleteEstate(id).subscribe(() => {
      this.router.navigate(['/estates/filter/paginated']);
    });
  }

  onBack(): void {
    this.router.navigate(['/estates/filter/paginated']);
  }
}
