import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class LoginContextService {
  private readonly _username$: BehaviorSubject<string> = new BehaviorSubject("");
  private readonly _password$: BehaviorSubject<string> = new BehaviorSubject("");

  public username$ = this._username$.asObservable();

  public password$ = this._password$.asObservable();
}
