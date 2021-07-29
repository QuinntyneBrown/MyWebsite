import { TestBed } from '@angular/core/testing';

import { DigitalAssetService } from './digital-asset.service';

describe('DigitalAssetService', () => {
  let service: DigitalAssetService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DigitalAssetService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
