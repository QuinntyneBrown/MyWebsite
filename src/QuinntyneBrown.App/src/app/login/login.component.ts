import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { AuthService, LocalStorageService, loginCredentialsKey, NavigationManager as NavigationManager } from '@core';
import { UserStore } from '@core/services/context/user-store.service';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnDestroy, OnInit {
  private readonly _destroyed$ = new Subject();
  private readonly _authService = inject(AuthService);
  private readonly _navigationManager = inject(NavigationManager);
  private readonly _localStorageService = inject(LocalStorageService);
  private readonly _userStore = inject(UserStore);

  ngOnInit() {
    this._authService.logout();

    const loginCredentials = this._localStorageService.get({ name: loginCredentialsKey });

    if (loginCredentials && loginCredentials.rememberMe) {
      this._userStore.username = loginCredentials.username;
      this._userStore.password = loginCredentials.password;
      this._userStore.rememberMe = loginCredentials.rememberMe;
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
      tap(_ => this._navigationManager.redirectPreLogin())
    )
    .subscribe();
  }

  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
