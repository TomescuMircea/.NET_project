
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
    expect(formValues.listingData).toBe('');
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
      listingData: '2023-01-01T00:00:00.000Z',
      id: '9eef8dcc-01e5-4c29-8620-860f4aeeeb53'
    };
    estateServiceMock.getEstateById.and.returnValue(of(estateData));
    component.ngOnInit();
    expect(component.estateForm.value).toEqual(estateData);
  });

  it('should call updateEstate and navigate on valid form submission', () => {
    component.estateForm.setValue({
      userId: 'ee06a4ca-79b7-4ce7-8f3b-354424226a09',
      name: 'Test Estate',
      description: 'Test Description',
      price: 100,
      address: 'Test Address',
      size: 200,
      type: 'A',
      status: 'Available',
      listingData: '2023-01-01T00:00:00.000Z',
      id: '9eef8dcc-01e5-4c29-8620-860f4aeeeb53'
    });
    component.onSubmit();
    expect(estateServiceMock.updateEstate).toHaveBeenCalled();
    expect(routerMock.navigate).toHaveBeenCalledWith(['/estates']);
  });
});