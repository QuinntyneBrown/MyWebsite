import { Component, Inject } from '@angular/core';
import { baseUrl } from '@core';
import { ShellContextService } from '@shared/shells/shell/shell-context.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent {

  public readonly vm$ = this._shellContextService.profile$
  .pipe(
    map(profile => ({ profile }))
  );

  constructor(
    @Inject(baseUrl) public baseUrl:string,
    private readonly _shellContextService: ShellContextService
  ) { }
}
