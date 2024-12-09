
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { EstateService } from '../../services/estate.service';
import { EstateUpdateComponent } from './estate-update.component';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { provideHttpClient } from '@angular/common/http';

describe('EstateUpdateComponent', () => {
  let component: EstateUpdateComponent;
  let fixture: ComponentFixture<EstateUpdateComponent>;
  let estateServiceMock: any;
  let routerMock: any;
  let activatedRouteMock: any;

  beforeEach(async () => {
    estateServiceMock = {
      getEstateById: jasmine.createSpy('getEstateById').and.returnValue(of({})),
      updateEstate: jasmine.createSpy('updateEstate').and.returnValue(of({}))
    };

    routerMock = {
      navigate: jasmine.createSpy('navigate')
    };

    activatedRouteMock = {
      snapshot: {
        paramMap: {
          get: jasmine.createSpy('get').and.returnValue('1')
        }
      }
    };

    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, EstateUpdateComponent], // Importă componenta aici
      providers: [
        { provide: EstateService, useValue: estateServiceMock },
        { provide: Router, useValue: routerMock },
        { provide: ActivatedRoute, useValue: activatedRouteMock },
        provideHttpClient(),
        provideHttpClientTesting()
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(EstateUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize the form with empty values', () => {
    const formValues = component.estateForm.value;
    expect(formValues.userId).toBe('');
    expect(formValues.name).toBe('');
    expect(formValues.description).toBe('');
    expect(formValues.price).toBe('');
    expect(formValues.address).toBe('');
    expect(formValues.size).toBe('');
    expect(formValues.type).toBe('');
    expect(formValues.status).toBe('');
    expect(formValues.id).toBe('');
  });

  it('should call getEstateById on init if estateId is present', () => {
    expect(estateServiceMock.getEstateById).toHaveBeenCalledWith('1');
  });

  it('should patch form values when getEstateById returns data', () => {
    const estateData = {
      userId: 'ee06a4ca-79b7-4ce7-8f3b-354424226a09',
      name: 'Test Estate',
      description: 'Test Description',
      price: 100,
      address: 'Test Address',
      size: 200,
      type: 'A',
      status: 'Available',
      id: '9eef8dcc-01e5-4c29-8620-860f4aeeeb53'
    };
    estateServiceMock.getEstateById.and.returnValue(of(estateData));
    component.ngOnInit();
    expect(component.estateForm.value).toEqual(estateData);
  });

    it('should not call updateEstate if form is invalid', () => {
    component.estateForm.setValue({
      userId: '',
      name: '',
      description: '',
      price: '',
      address: '',
      size: '',
      type: '',
      status: '',
      id: ''
    });
    component.onSubmit();
    expect(estateServiceMock.updateEstate).not.toHaveBeenCalled();
    expect(routerMock.navigate).not.toHaveBeenCalled();
    });

    it('should set errorMessage if user is not logged in', () => {
    spyOn(component['userService'], 'getUserId').and.returnValue(null as any);
    component.estateForm.setValue({
      userId: 'ee06a4ca-79b7-4ce7-8f3b-354424226a09',
      name: 'Test Estate',
      description: 'Test Description',
      price: 100,
      address: 'Test Address',
      size: 200,
      type: 'A',
      status: 'Available',
      id: '9eef8dcc-01e5-4c29-8620-860f4aeeeb53'
    });
    component.onSubmit();
    expect(component.errorMessage).toBe('You must log in.');
    expect(estateServiceMock.updateEstate).not.toHaveBeenCalled();
    expect(routerMock.navigate).not.toHaveBeenCalled();
    });

    it('should set errorMessage if user is not authorized to edit the estate', () => {
    spyOn(component['userService'], 'getUserId').and.returnValue('different-user-id');
    component.estateForm.setValue({
      userId: 'ee06a4ca-79b7-4ce7-8f3b-354424226a09',
      name: 'Test Estate',
      description: 'Test Description',
      price: 100,
      address: 'Test Address',
      size: 200,
      type: 'A',
      status: 'Available',
      id: '9eef8dcc-01e5-4c29-8620-860f4aeeeb53'
    });
    component.onSubmit();
    expect(component.errorMessage).toBe('You are not authorized to edit this estate.');
    expect(estateServiceMock.updateEstate).not.toHaveBeenCalled();
    expect(routerMock.navigate).not.toHaveBeenCalled();
    });
});