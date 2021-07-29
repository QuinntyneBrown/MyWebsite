import { Route as NgRoute, Routes } from '@angular/router';
import { ShellComponent } from './shell.component';

export class Route {
  static withShell(routes: Routes): NgRoute {
    return {
      path: '',
      component: ShellComponent,
      children: routes,
      data: {
        reuse: true
      }
    };
  }
};
