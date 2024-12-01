import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EstateListComponent } from './estate-list.component';
import { EstateService } from '../../services/estate.service';
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { CommonModule } from '@angular/common';

describe('EstateListComponent', () => {
  let component: EstateListComponent;
  let fixture: ComponentFixture<EstateListComponent>;
  let estateServiceMock: any;
  let routerMock: any;

  beforeEach(async () => {
    
    estateServiceMock = {
      getPaginatedEstates: jasmine.createSpy('getPaginatedEstates').and.returnValue(of({
        data: {
          data: [
            { id: '1', name: 'Estate 1', address: 'Address 1', price: 100, size: 50, listingData: '2024-01-01' },
            { id: '2', name: 'Estate 2', address: 'Address 2', price: 200, size: 100, listingData: '2024-01-02' }
          ],
          totalCount: 6
        }
      }))
    };

    // Mock Router
    routerMock = {
      navigate: jasmine.createSpy('navigate')
    };

    await TestBed.configureTestingModule({
      imports: [CommonModule, EstateListComponent],
      providers: [
        { provide: EstateService, useValue: estateServiceMock },
        { provide: Router, useValue: routerMock }
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstateListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should load estates on initialization', () => {
    component.pageSize = 4;
    component.ngOnInit();
    expect(estateServiceMock.getPaginatedEstates).toHaveBeenCalledWith(1, 4);
    expect(component.estates.length).toBe(2); 
    expect(component.totalPages).toBe(2); 
  });

  it('should navigate to the create estate page', () => {
    component.navigateToCreateEstate();
    expect(routerMock.navigate).toHaveBeenCalledWith(['estates/create']);
  });

  it('should navigate to the update estate page', () => {
    const id = '123';
    component.navigateToUpdateEstate(id);
    expect(routerMock.navigate).toHaveBeenCalledWith(['estates/update', id]);
  });

  it('should navigate to the detail estate page', () => {
    const id = '123';
    component.navigateToDetailEstate(id);
    expect(routerMock.navigate).toHaveBeenCalledWith(['estates/detail', id]);
  });

  it('should change page and load estates', () => {
    component.currentPage = 1;
    component.pageSize = 4;
    component.totalPages = 3;
    component.changePage(true);
    expect(component.currentPage).toBe(2);
    expect(estateServiceMock.getPaginatedEstates).toHaveBeenCalledWith(2, 4);
  });

  it('should not change page if on the first page and "previous" is clicked', () => {
    component.currentPage = 1;
    component.pageSize = 4;
    component.changePage(false);
    expect(component.currentPage).toBe(1);
    expect(estateServiceMock.getPaginatedEstates).toHaveBeenCalledWith(1, 4);
  });

  it('should change page size and reset to the first page', () => {
    const event = { target: { value: '5' } } as unknown as Event;
    component.changePageSize(event);
    expect(component.pageSize).toBe(5);
    expect(component.currentPage).toBe(1); 
    expect(estateServiceMock.getPaginatedEstates).toHaveBeenCalledWith(1, 5);
  });

  it('should go to a specific page and load estates', () => {
    component.pageSize = 4;
    component.goToPage(3);
    expect(component.currentPage).toBe(3);
    expect(estateServiceMock.getPaginatedEstates).toHaveBeenCalledWith(3, 4);
  });

  it('should return the correct pages array', () => {
    component.totalPages = 3;
    expect(component.getPagesArray()).toEqual([1, 2, 3]); 
  });

  it('should not change page if on the last page and "next" is clicked', () => {
    component.currentPage = 3;
    component.pageSize = 4;
    component.totalPages = 3;
    component.changePage(true);
    expect(component.currentPage).toBe(3);
    expect(estateServiceMock.getPaginatedEstates).toHaveBeenCalledWith(3, 4);
  });

  it('should change to the next page if not on the last page and "next" is clicked', () => {
    component.currentPage = 2;
    component.pageSize = 4;
    component.totalPages = 3;
    component.changePage(true);
    expect(component.currentPage).toBe(3);
    expect(estateServiceMock.getPaginatedEstates).toHaveBeenCalledWith(3, 4);
  });

  it('should change to the previous page if not on the first page and "previous" is clicked', () => {
    component.currentPage = 2;
    component.pageSize = 4;
    component.totalPages = 3;
    component.changePage(false);
    expect(component.currentPage).toBe(1);
    expect(estateServiceMock.getPaginatedEstates).toHaveBeenCalledWith(1, 4);
  });
});