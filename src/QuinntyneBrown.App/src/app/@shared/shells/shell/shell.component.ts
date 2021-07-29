import { Component } from '@angular/core';
import { ProfileService } from '@api';
import { shareReplay } from 'rxjs/operators';
import { ShellContextService } from './shell-context.service';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss'],
  providers:[
    ShellContextService
  ]
})
export class ShellComponent  {
  constructor(
    private readonly _shellContextService: ShellContextService
  ) {

  }
}
