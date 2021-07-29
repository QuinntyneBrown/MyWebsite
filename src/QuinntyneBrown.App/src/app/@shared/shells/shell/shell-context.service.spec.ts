import { TestBed } from '@angular/core/testing';

import { ShellContextService } from './shell-context.service';

describe('ShellContextService', () => {
  let service: ShellContextService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShellContextService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
