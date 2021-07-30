import { Component } from '@angular/core';
import { LoginContextService } from '../login-context.service';

@Component({
  selector: 'app-password-form',
  templateUrl: './password-form.component.html',
  styleUrls: ['./password-form.component.scss']
})
export class PasswordFormComponent {

  constructor(
    private readonly _loginContextService: LoginContextService
  ) { }


}
