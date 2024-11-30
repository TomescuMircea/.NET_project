import { TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { EstateService } from './estate.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Estate } from '../models/estate.model';

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
describe('EstateService', () => {
  let service: EstateService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [EstateService]
    });
    service = TestBed.inject(EstateService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should retrieve estates from the API via GET', () => {
    const dummyEstates: Estate[] = [
      {
        userId: 'ee06a4ca-79b7-4ce7-8f3b-354424226a09',
        name: 'Test Estate1',
        description: 'Test Description1',
        price: 100,
        address: 'Test Address1',
        size: 200,
        type: 'A',
        status: 'Available',
        listingData: new Date('2023-01-01T00:00:00.000Z'),
        id: '9eef8dcc-01e5-4c29-8620-860f4aeeeb53'},
      {
        userId: 'ee06a4ca-79b7-4ce7-8f3b-354424226a09',
        name: 'Test Estate2',
        description: 'Test Description2',
        price: 100,
        address: 'Test Address2',
        size: 200,
        type: 'A',
        status: 'Unnavailable',
        listingData: new Date('2023-01-01T00:00:00.000Z'),
        id: '9eef8dcc-01e5-4c29-8620-860f4aeeeb53'}
    ];

    service.getEstates().subscribe(estates => {
      expect(estates.length).toBe(2);
      expect(estates).toEqual(dummyEstates);
    });

    const request = httpMock.expectOne(`${service['apiURL']}`);
    expect(request.request.method).toBe('GET');
    request.flush(dummyEstates);
  });

  it('should create a new estate via POST', () => {
    const newEstate: Estate ={
      userId: 'ee06a4ca-79b7-4ce7-8f3b-354424226a09',
      name: 'Test Estate3',
      description: 'Test Description3',
      price: 100,
      address: 'Test Address3',
      size: 200,
      type: 'A',
      status: 'Available3',
      listingData: new Date('2023-01-01T00:00:00.000Z'),
      id: '9eef8dcc-01e5-4c29-8620-860f4aeeeb53'};

    service.createEstate(newEstate).subscribe(estate => {
      expect(estate).toEqual(newEstate);
    });

    const request = httpMock.expectOne(`${service['apiURL']}`);
    expect(request.request.method).toBe('POST');
    request.flush(newEstate);
  });

  it('should update an existing estate via PUT', () => {
    const updatedEstate: Estate = {
      userId: 'ee06a4ca-79b7-4ce7-8f3b-354424226a09',
      name: 'Test Estate4',
      description: 'Test Description4',
      price: 100,
      address: 'Test Address4',
      size: 200,
      type: 'A',
      status: 'Unnavailable',
      listingData: new Date('2023-01-01T00:00:00.000Z'),
      id: '9eef8dcc-01e5-4c29-8620-860f4aeeeb53'};

    service.updateEstate(updatedEstate).subscribe(estate => {
      expect(estate).toEqual(updatedEstate);
    });

    const request = httpMock.expectOne(`${service['apiURL']}/9eef8dcc-01e5-4c29-8620-860f4aeeeb53`);
    expect(request.request.method).toBe('PUT');
    request.flush(updatedEstate);
  });

  it('should retrieve an estate by ID via GET', () => {
    const dummyEstate: Estate = {
      userId: 'ee06a4ca-79b7-4ce7-8f3b-354424226a09',
      name: 'Test Estate',
      description: 'Test Description',
      price: 100,
      address: 'Test Address',
      size: 200,
      type: 'A',
      status: 'Available',
      listingData: new Date('2023-01-01T00:00:00.000Z'),
      id: '9eef8dcc-01e5-4c29-8620-860f4aeeeb53'};

    service.getEstateById('9eef8dcc-01e5-4c29-8620-860f4aeeeb53').subscribe(estate => {
      expect(estate).toEqual(dummyEstate);
    });

    const request = httpMock.expectOne(`${service['apiURL']}/9eef8dcc-01e5-4c29-8620-860f4aeeeb53`);
    expect(request.request.method).toBe('GET');
    request.flush(dummyEstate);
  });

  it('should delete an estate by ID via DELETE', () => {
    service.deleteEstate('9eef8dcc-01e5-4c29-8620-860f4aeeeb53').subscribe(response => {
      expect(response).toBeTruthy();
    });

    const request = httpMock.expectOne(`${service['apiURL']}/9eef8dcc-01e5-4c29-8620-860f4aeeeb53`);
    expect(request.request.method).toBe('DELETE');
    request.flush({});
  });
});
