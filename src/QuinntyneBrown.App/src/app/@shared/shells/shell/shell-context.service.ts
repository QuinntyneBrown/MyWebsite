import { Injectable } from '@angular/core';
import { ProfileService } from '@api';
import { shareReplay } from 'rxjs/operators';

@Injectable()
export class ShellContextService {

  public readonly profile$ = this._profileService.get()
  .pipe(
    shareReplay(1)
  );

  constructor(
    private readonly _profileService: ProfileService
  ) {

  }
}
