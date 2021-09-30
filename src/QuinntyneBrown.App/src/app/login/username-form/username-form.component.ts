import { Component } from '@angular/core';
import { UserContextService } from '@core/services/context/user-context.service';


@Component({
  selector: 'app-username-form',
  templateUrl: './username-form.component.html',
  styleUrls: ['./username-form.component.scss']
})
export class UsernameFormComponent {

  constructor(private readonly _userContextService: UserContextService) { }


}
