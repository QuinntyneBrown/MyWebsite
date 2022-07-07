import { ActivatedRouteSnapshot, DetachedRouteHandle, RouteReuseStrategy } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class RouteReusableStrategy extends RouteReuseStrategy {

  public shouldDetach(route: ActivatedRouteSnapshot): boolean {
    return false;
  }

  public store(route: ActivatedRouteSnapshot, detachedTree: DetachedRouteHandle | null): void { }

  public shouldAttach(route: ActivatedRouteSnapshot): boolean {
    return false;
  }

  public retrieve(route: ActivatedRouteSnapshot): DetachedRouteHandle | null {
    return null;
  }

  public shouldReuseRoute(future: ActivatedRouteSnapshot, curr: ActivatedRouteSnapshot): boolean {
    return (future.routeConfig === curr.routeConfig) || future.data.reuse;
  }

}
