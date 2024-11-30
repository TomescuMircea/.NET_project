import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EstateCreateComponent } from './estate-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { of } from 'rxjs'; //observable mock
import { EstateService } from '../../services/estate.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

//definirea unei suite de teste pentru componenta
describe('EstateCreateComponent', () => {
  let component: EstateCreateComponent;
  let fixture: ComponentFixture<EstateCreateComponent>; //wrapper pentru componenta care permite accesul la proprietati si metode ale componentei
  let estateServiceMock: any; //mock-uri
  let routerMock: any;

 
  beforeEach(async () => {
    // estateServiceMock este un mock pentru EstateService
    estateServiceMock = {
      createEstate: jasmine.createSpy('createEstate').and.returnValue(of({}))
    };
  
    // routerMock este un mock pentru Router
    routerMock = {
      navigate: jasmine.createSpy('navigate')
    };
  
    // Configurare modul de testare
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, HttpClientTestingModule, EstateCreateComponent], // Adaugă HttpClientTestingModule aici
      providers: [
        { provide: EstateService, useValue: estateServiceMock },
        { provide: Router, useValue: routerMock }
      ]
    }).compileComponents();
  
    fixture = TestBed.createComponent(EstateCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have a valid form when all fields are filled correctly', () => {
    component.estateForm.setValue({
      userId: '123e4567-e89b-12d3-a456-426614174000',
      name: 'Test Estate',
      description: 'Test Description',
      price: 100,
      address: 'Test Address',
      size: 100,
      type: 'A',
      status: 'Available',
      listingData: '2023-10-10'
    });
    expect(component.estateForm.valid).toBeTrue();
  });

  it('should have an invalid form when required fields are missing', () => {
    component.estateForm.setValue({
      userId: '',
      name: '',
      description: '',
      price: '',
      address: '',
      size: '',
      type: '',
      status: '',
      listingData: ''
    });
    expect(component.estateForm.invalid).toBeTrue();
  });

  it('should call createEstate and navigate on valid form submission', () => {
    component.estateForm.setValue({
      userId: '123e4567-e89b-12d3-a456-426614174000',
      name: 'Test Estate',
      description: 'Test Description',
      price: 100,
      address: 'Test Address',
      size: 100,
      type: 'A',
      status: 'Available',
      listingData: '2023-10-10'
    });

    component.onSubmit();

    expect(estateServiceMock.createEstate).toHaveBeenCalledWith(component.estateForm.value);
    expect(routerMock.navigate).toHaveBeenCalledWith(['/estates']);
  });

  it('should not call createEstate on invalid form submission', () => {
    component.estateForm.setValue({
      userId: '',
      name: '',
      description: '',
      price: '',
      address: '',
      size: '',
      type: '',
      status: '',
      listingData: ''
    });

    component.onSubmit();

    expect(estateServiceMock.createEstate).not.toHaveBeenCalled();
    expect(routerMock.navigate).not.toHaveBeenCalled();
  });
});
