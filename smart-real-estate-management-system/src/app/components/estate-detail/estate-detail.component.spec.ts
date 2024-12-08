import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideHttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { EstateDetailComponent } from './estate-detail.component';
import { EstateService } from '../../services/estate.service';
import { provideHttpClientTesting } from '@angular/common/http/testing';

describe('EstateDetailComponent', () => {
  let component: EstateDetailComponent;
  let fixture: ComponentFixture<EstateDetailComponent>;
  let estateServiceMock: any;
  let routerMock: any;
  let activatedRouteMock: any;

  beforeEach(async () => {
    estateServiceMock = {
      getEstateById: jasmine.createSpy('getEstateById').and.returnValue(of({})),
      deleteEstate: jasmine.createSpy('deleteEstate').and.returnValue(of({}))
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
      imports: [EstateDetailComponent],
      providers: [
        { provide: EstateService, useValue: estateServiceMock },
        { provide: Router, useValue: routerMock },
        { provide: ActivatedRoute, useValue: activatedRouteMock },
        provideHttpClient(),
        provideHttpClientTesting()
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(EstateDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch estate details on init', () => {
    expect(estateServiceMock.getEstateById).toHaveBeenCalledWith('1');
    expect(component.estate).toEqual({});
  });

  it('should navigate to estates list on delete', () => {
    component.onDelete('1');
    expect(estateServiceMock.deleteEstate).toHaveBeenCalledWith('1');
    expect(routerMock.navigate).toHaveBeenCalledWith(['/estates/filter/paginated']);
  });
});
