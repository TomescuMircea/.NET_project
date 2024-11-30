import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { EstateDetailComponent } from './estate-detail.component';
import { EstateService } from '../../services/estate.service';

describe('EstateDetailComponent', () => {
  let component: EstateDetailComponent;
  let fixture: ComponentFixture<EstateDetailComponent>;
  let estateServiceMock: any;
  let activatedRouteMock: any;

  beforeEach(async () => {
    estateServiceMock = {
      getEstateById: jasmine.createSpy('getEstateById').and.returnValue(of({}))
    };

    activatedRouteMock = {
      snapshot: {
        paramMap: {
          get: jasmine.createSpy('get').and.returnValue('1')
        }
      }
    };

    await TestBed.configureTestingModule({
      imports: [HttpClientModule, EstateDetailComponent],
      providers: [
        { provide: EstateService, useValue: estateServiceMock },
        { provide: ActivatedRoute, useValue: activatedRouteMock }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(EstateDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
