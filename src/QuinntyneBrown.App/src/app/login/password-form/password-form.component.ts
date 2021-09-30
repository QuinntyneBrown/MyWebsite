import { Component } from '@angular/core';
import { UserContextService } from '@core/services/context/user-context.service';


@Component({
  selector: 'app-password-form',
  templateUrl: './password-form.component.html',
  styleUrls: ['./password-form.component.scss']
})
export class PasswordFormComponent {

  constructor(
    private readonly _userContextService: UserContextService
  ) { }


}
