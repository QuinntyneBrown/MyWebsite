import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserStore {
  private readonly _username$: BehaviorSubject<string> = new BehaviorSubject("");
  private readonly _password$: BehaviorSubject<string> = new BehaviorSubject("");
  private readonly _rememberMe$: BehaviorSubject<boolean> = new BehaviorSubject(false);

  public set username(value:string) {
    this._username$.next(value);
  }

  public set password(value:string) {
    this._password$.next(value);
  }

  public set rememberMe(value:boolean) {
    this._rememberMe$.next(value);
  }

  public username$ = this._username$.asObservable();
  public password$ = this._password$.asObservable();
  public rememberMe$ = this._rememberMe$.asObservable();
}
