import { Component, inject } from '@angular/core';
import { ProfileStore } from '@core/services/context/profile-store.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  private readonly _profileStore = inject(ProfileStore);

  public vm$ = this._profileStore.profile$
  .pipe(
    map(profile => ({ profile }))
  );
}
