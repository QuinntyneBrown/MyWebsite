import { Component, OnDestroy } from '@angular/core';
import { AuthService, NavigationService } from '@core';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';
import { LoginContextService } from './login-context.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [
    LoginContextService
  ]
})
export class LoginComponent implements OnDestroy {

  private readonly _destroyed$ = new Subject();

  constructor(
    private readonly _authService: AuthService,
    private readonly _navigationService: NavigationService
  ) { }

  public handleLoginClick($event: any) {
    this._authService
    .tryToLogin({
      username: $event.username,
      password: $event.password
    })
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._navigationService.redirectPreLogin())
    )
    .subscribe();
  }

  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
