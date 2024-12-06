import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EstateCreateComponent } from './estate-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { EstateService } from '../../services/estate.service';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { provideHttpClient } from '@angular/common/http';

describe('EstateCreateComponent', () => {
  let component: EstateCreateComponent;
  let fixture: ComponentFixture<EstateCreateComponent>; 
  let estateServiceMock: any;
  let routerMock: any;

 
  beforeEach(async () => {
    estateServiceMock = {
      createEstate: jasmine.createSpy('createEstate').and.returnValue(of({}))
    };
  
    routerMock = {
      navigate: jasmine.createSpy('navigate')
    };
  
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, EstateCreateComponent], // Adaugă HttpClientTestingModule aici
      providers: [
        { provide: EstateService, useValue: estateServiceMock },
        { provide: Router, useValue: routerMock },
        provideHttpClient(),  
        provideHttpClientTesting()
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
      name: 'Test Estate',
      description: 'Test Description',
      price: 100,
      address: 'Test Address',
      size: 100,
      type: 'A',
      status: 'Available',
    });
    expect(component.estateForm.valid).toBeTrue();
  });

  it('should have an invalid form when required fields are missing', () => {
    component.estateForm.setValue({
      name: '',
      description: '',
      price: '',
      address: '',
      size: '',
      type: '',
      status: '',
    });
    expect(component.estateForm.invalid).toBeTrue();
  });

  it('should call createEstate and navigate on valid form submission', () => {
    component.estateForm.setValue({
      name: 'Test Estate',
      description: 'Test Description',
      price: 100,
      address: 'Test Address',
      size: 100,
      type: 'A',
      status: 'Available',
    });

    component.onSubmit();

    expect(estateServiceMock.createEstate).toHaveBeenCalledWith(component.estateForm.value);
    expect(routerMock.navigate).toHaveBeenCalledWith(['/estates/paginated']);
  });

  it('should not call createEstate on invalid form submission', () => {
    component.estateForm.setValue({
      name: '',
      description: '',
      price: '',
      address: '',
      size: '',
      type: '',
      status: '',
    });

    component.onSubmit();

    expect(estateServiceMock.createEstate).not.toHaveBeenCalled();
    expect(routerMock.navigate).not.toHaveBeenCalled();
  });
});
