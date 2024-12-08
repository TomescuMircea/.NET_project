
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
  styleUrls: ['./estate-list.component.css']
})
export class EstateListComponent implements OnInit {
  estates: Estate[] = [];
  currentPage: number = 1;
  totalPages: number= 0;
  pageSize: number = 5; 
  pageSizeOptions: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]; 

  constructor(private readonly estateService: EstateService, 
              private readonly router: Router) {}

  ngOnInit(): void {
    this.loadEstates();
  }


  loadEstates(): void {
    this.estateService.getPaginatedEstates(this.currentPage, this.pageSize).subscribe((data: any) => {
      this.estates = data.data.data;
      this.totalPages=Math.ceil(data.data.totalCount/this.pageSize);
     
    });
  }

  changePage(next: boolean): void {
    if (next && this.currentPage < this.totalPages) {
      this.currentPage++;
    } else if (!next && this.currentPage > 1) {
      this.currentPage--;
    }
    this.loadEstates();
  }

  changePageSize(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const size = selectElement.value;
    if (size) {
      this.pageSize = Number(size);
      this.currentPage = 1; 
      this.loadEstates();
    }
  }

  goToPage(page: number): void {
    if (page !== this.currentPage) {
      this.currentPage = page;
      this.loadEstates();
    }
  }
  
  getPagesArray(): number[] {
    return Array.from({ length: this.totalPages }, (_, index) => index + 1);
  }

  navigateToHome(): void {  
    this.router.navigate(['']);
   }
  
  navigateToCreateEstate(): void {
        this.router.navigate(['estates/create']);
       }
    
  navigateToUpdateEstate(id: string): void {
        this.router.navigate(['estates/update', id]);
       }
    
   navigateToDetailEstate(id: string): void {
         this.router.navigate(['estates/detail', id]);
      }
}
