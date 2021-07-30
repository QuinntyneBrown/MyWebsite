import { Component } from '@angular/core';
import { LoginContextService } from '../login-context.service';

@Component({
  selector: 'app-remember-me',
  templateUrl: './remember-me.component.html',
  styleUrls: ['./remember-me.component.scss']
})
export class RememberMeComponent {

  constructor(private readonly _loginContextService: LoginContextService) { }



}
