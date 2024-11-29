import { Component, OnInit } from '@angular/core';
import { Estate } from '../../models/estate.model';
import { EstateService } from '../../services/estate.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-estate-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './estate-list.component.html',
  styleUrl: './estate-list.component.css'
})
export class EstateListComponent implements OnInit {
  
  estates: Estate[] = [];
  constructor(private estateService: EstateService, private router: Router) { }

  ngOnInit(): void {
    this.estateService.getEstates().subscribe((data: Estate[]) => {
      this.estates = data;
    });
  }

  navigateToCreateEstate(): void {
    this.router.navigate(['estates/create']);
  }

  navigateToUpdateEstate(id: string): void {
    this.router.navigate(['estates/update', id]);
  }
}
