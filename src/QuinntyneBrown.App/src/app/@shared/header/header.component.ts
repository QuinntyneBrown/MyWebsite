import { Component } from '@angular/core';
import { ProfileContextService } from '@core/services/context/profile-context.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  public vm$ = this._profileContextService.profile$
  .pipe(
    map(profile => ({ profile }))
  );

  constructor(
    private readonly _profileContextService: ProfileContextService
  ) { }
}
