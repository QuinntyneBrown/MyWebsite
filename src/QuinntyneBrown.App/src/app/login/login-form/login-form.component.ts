import { Component, Output, EventEmitter, Renderer2, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserContextService } from '@core/services/context/user-context.service';
import { combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent {


  public vm$ = combineLatest([
    this._userContextService.username$,
    this._userContextService.password$
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

  constructor(
    private readonly _renderer: Renderer2,
    private readonly _userContextService: UserContextService
    ) { }
}
