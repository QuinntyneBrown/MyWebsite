import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { NavigationService } from '../services/functional/navigation.service';
import { LocalStorageService } from '@core';
import { accessTokenKey } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private readonly _localStorageService: LocalStorageService,
    private readonly _navigationService: NavigationService
  ) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const token = this._localStorageService.get({ name: accessTokenKey });
      if (token) {
        return true;
      }

      this._navigationService.lastPath = state.url;
      this._navigationService.redirectToLogin();

      return false;
  }
}
