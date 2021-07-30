import { Component, Output, EventEmitter, Renderer2 } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';
import { LoginContextService } from '../login-context.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent {

  public vm$ = combineLatest([
    this._loginContextService.username$,
    this._loginContextService.password$
  ]).pipe(
    map(([username,password]) => ({
      form:new FormGroup({
        username: new FormControl(username, [Validators.required]),
        password: new FormControl(password, [Validators.required])
      })
    }))
  );


  @Output() public tryToLogin: EventEmitter<{ username: string, password: string }> = new EventEmitter();

  constructor(
    private readonly _renderer: Renderer2,
    private readonly _loginContextService: LoginContextService
    ) { }
}
