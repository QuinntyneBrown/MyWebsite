import { inject, Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { NavigationManager } from '../services/functional/navigation-manager.service';
import { LocalStorageService } from '@core';
import { accessTokenKey } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  private readonly _localStorageService = inject(LocalStorageService);
  private readonly _navigationManager = inject(NavigationManager);

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const token = this._localStorageService.get({ name: accessTokenKey });
      if (token) {
        return true;
      }

      this._navigationManager.lastPath = state.url;
      this._navigationManager.redirectToLogin();

      return false;
  }
}
