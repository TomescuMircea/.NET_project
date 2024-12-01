import { TestBed } from '@angular/core/testing';
import { EstateService } from './estate.service';
import { provideHttpClient } from '@angular/common/http';
import { provideHttpClientTesting } from '@angular/common/http/testing';

describe('EstateService', () => {
  let service: EstateService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [], 
      providers: [
        provideHttpClient(),
        provideHttpClientTesting()
      ] 
    });
    service = TestBed.inject(EstateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
