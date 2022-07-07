import { Injectable } from '@angular/core';
import { ProfileService } from '@api';
import { fullname } from '@core';
import { shareReplay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProfileStore {
  public readonly profile$ = this._profileService.getByName({ fullname })
  .pipe(
    shareReplay(1)
  );

  constructor(
    private readonly _profileService: ProfileService
  ) { }
}
