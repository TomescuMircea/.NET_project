import { Component, OnInit } from '@angular/core';
import { Estate } from '../../models/estate.model';
import { EstateService } from '../../services/estate.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // Importă FormsModule

import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';


@Component({
  selector: 'app-estate-list',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './estate-list.component.html',
  styleUrls: ['./estate-list.component.css']
})
export class EstateListComponent implements OnInit {
  estates: Estate[] = [];
  currentPage: number = 1;
  totalPages: number= 0;
  pageSize: number = 5; 
  pageSizeOptions: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]; 
  filterForm: FormGroup;
  
  filter = {
    name: '',
    address: '',
    type: '',
    price: 0,
    size: 0
  };

  constructor(private readonly estateService: EstateService, 
              private readonly router: Router,
              private fb: FormBuilder) {
                this.filterForm = this.fb.group({
                  name: ['', [Validators.maxLength(100)]],
                  address: ['', [Validators.maxLength(200)]],
                  type: ['', [Validators.maxLength(100)]],
                  price: [0, [Validators.min(0)]],
                  size: [0, [Validators.min(0)]]
                });
              }

  ngOnInit(): void {
    this.loadEstates();
    this.initializeCollapsible();
  }

  applyFilter(): void {
    console.log('Applying filter:', this.filter);
    this.currentPage = 1; // Reset page to 1 when applying a new filter
    this.loadEstates();
  }

  initializeCollapsible(): void {
    const coll = document.getElementsByClassName("filter-collapsible");
    for (let i = 0; i < coll.length; i++) {
      coll[i].addEventListener("click", function(this: HTMLElement) {
        this.classList.toggle("active");
        const content = this.nextElementSibling as HTMLElement;
        if (content.style.display === "block") {
          content.style.display = "none";
        } else {
          content.style.display = "block";
        }
      });
    }
  }

  loadEstates(): void {
    console.log('Loading estates with filter:', this.filter);
    this.estateService.getPaginatedEstates(
      this.filter.name,
      this.filter.address,
      this.filter.type,
      this.filter.price,
      this.filter.size,
      this.currentPage,
      this.pageSize
    ).subscribe((data: any) => {
      console.log('Estates loaded:', data);
      this.estates = data.data.data;
      this.totalPages = Math.ceil(data.data.totalCount / this.pageSize);
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
