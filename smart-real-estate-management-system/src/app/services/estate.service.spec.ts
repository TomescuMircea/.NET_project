import { TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { EstateService } from './estate.service';

describe('EstateService', () => {
  let service: EstateService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule] // Importă HttpClientModule aici
    });
    service = TestBed.inject(EstateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
