import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Route } from '@shared/shells/shell/route';
import { Route as WorkspaceRoute } from '@shared/shells/workspace-shell/route';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'landing' },
  { path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) },
  Route.withShell([{ path: 'landing', loadChildren: () => import('./landing/landing.module').then(m => m.LandingModule) }]),
  WorkspaceRoute.withShell([{ path: 'video', loadChildren: () => import('./video/video.module').then(m => m.VideoModule) }])
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
