import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService, LocalStorageService, loginCredentialsKey, NavigationService } from '@core';
import { UserContextService } from '@core/services/context/user-context.service';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnDestroy, OnInit {
  private readonly _destroyed$ = new Subject();

  constructor(
    private readonly _authService: AuthService,
    private readonly _navigationService: NavigationService,
    private readonly _localStorageService: LocalStorageService,
    private readonly _userContextService: UserContextService
  ) { }

  ngOnInit() {
    this._authService.logout();

    const loginCredentials = this._localStorageService.get({ name: loginCredentialsKey });

    if (loginCredentials && loginCredentials.rememberMe) {
      this._userContextService.username = loginCredentials.username;
      this._userContextService.password = loginCredentials.password;
      this._userContextService.rememberMe = loginCredentials.rememberMe;
    }
  }

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
