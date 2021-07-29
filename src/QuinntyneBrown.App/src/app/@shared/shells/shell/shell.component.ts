import { Component } from '@angular/core';
import { ShellContextService } from './shell-context.service';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss'],
  providers:[
    ShellContextService
  ]
})
export class ShellComponent  { }
