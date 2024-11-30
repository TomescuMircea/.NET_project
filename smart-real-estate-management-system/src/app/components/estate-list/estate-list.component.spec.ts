// import { ComponentFixture, TestBed } from '@angular/core/testing';
// import { of } from 'rxjs';
// import { EstateListComponent } from './estate-list.component';
// import { EstateService } from '../../services/estate.service';
// import { provideHttpClientTesting } from '@angular/common/http/testing';
// import { provideHttpClient } from '@angular/common/http';
// import { Router } from '@angular/router';


// describe('EstateListComponent', () => {
//   let component: EstateListComponent;
//   let fixture: ComponentFixture<EstateListComponent>;
//   let estateServiceMock: any;
//   let routerMock: any;

//   beforeEach(async () => {

//     estateServiceMock = {
//       createEstate: jasmine.createSpy('getEstates').and.returnValue(of({}))
//     };
  
//     routerMock = {
//       navigate: jasmine.createSpy('navigate')
//     };
//     await TestBed.configureTestingModule({
//       imports: [EstateListComponent],
//       providers: [
//         { provide: EstateService, useValue: estateServiceMock },
//         { provide: Router, useValue: routerMock },

//         provideHttpClient(),
//         provideHttpClientTesting()
//       ]
//     })
//     .compileComponents();
//     fixture = TestBed.createComponent(EstateListComponent);
//     component = fixture.componentInstance;
//     fixture.detectChanges();
   
//   });






// });






