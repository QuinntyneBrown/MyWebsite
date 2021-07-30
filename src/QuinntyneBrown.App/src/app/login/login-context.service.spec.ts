import { TestBed } from '@angular/core/testing';

import { LoginContextService } from './login-context.service';

describe('LoginContextService', () => {
  let service: LoginContextService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoginContextService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
