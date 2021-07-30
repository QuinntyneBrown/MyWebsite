import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class LoginContextService {
  private readonly _username$: BehaviorSubject<string> = new BehaviorSubject("quinntynebrown@gmail.com");
  private readonly _password$: BehaviorSubject<string> = new BehaviorSubject("P@ssw0rd");

  public username$ = this._username$.asObservable();

  public password$ = this._password$.asObservable();
}
