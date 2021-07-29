import { Route as NgRoute, Routes } from '@angular/router';
import { WorkspaceShellComponent } from './workspace-shell.component';

export class Route {
  static withShell(routes: Routes): NgRoute {
    return {
      path: '',
      component: WorkspaceShellComponent,
      children: routes
    };
  }
};
