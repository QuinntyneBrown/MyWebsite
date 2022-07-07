import { Component, Output, EventEmitter, Renderer2, Input, inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserStore } from '@core/services/context/user-store.service';
import { combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent {

  private readonly _userStore = inject(UserStore);

  public vm$ = combineLatest([
    this._userStore.username$,
    this._userStore.password$
  ]).pipe(
    map(([username,password]) => ({
      form:new FormGroup({
        username: new FormControl(username, [Validators.required]),
        password: new FormControl(password, [Validators.required]),
        rememberMe: new FormControl(null,[])
      })
    }))
  );


  @Output() public tryToLogin: EventEmitter<{ username: string, password: string }> = new EventEmitter();


}
