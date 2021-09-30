import { Component } from '@angular/core';
import { UserContextService } from '@core/services/context/user-context.service';


@Component({
  selector: 'app-remember-me',
  templateUrl: './remember-me.component.html',
  styleUrls: ['./remember-me.component.scss']
})
export class RememberMeComponent {

  constructor(private readonly _userContextService: UserContextService) { }



}
