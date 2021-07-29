import { Component } from '@angular/core';
import { ShellContextService } from '@shared/shells/shell/shell-context.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  public vm$ = this._shellContextService.profile$
  .pipe(
    map(profile => ({ profile }))
  );

  constructor(
    private readonly _shellContextService: ShellContextService
  ) {

  }

  public handleSocialClick(url:string) {
    alert(url);
    document.location.href = url;
  }
}
