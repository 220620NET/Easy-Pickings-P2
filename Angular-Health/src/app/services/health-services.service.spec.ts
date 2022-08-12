import { TestBed } from '@angular/core/testing';

import { HealthServicesService } from './health-services.service';

describe('HealthServicesService', () => {
  let service: HealthServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HealthServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
