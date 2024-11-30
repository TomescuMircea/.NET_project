import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EstateService } from '../../services/estate.service';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-estate-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './estate-detail.component.html',
  styleUrl: './estate-detail.component.css'
})
export class EstateDetailComponent implements OnInit {
  estate: any;

  constructor(
    private route: ActivatedRoute,
    private estateService: EstateService,
    private router: Router
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
    this.estateService.deleteEstate(id).subscribe(() => {
      this.router.navigate(['/estates']);
    });
  }
}
