import { TestBed } from '@angular/core/testing';

import { ProfileContextService } from './profile-context.service';

describe('ProfileContextService', () => {
  let service: ProfileContextService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProfileContextService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
