import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { WorkspaceShellComponent } from './workspace-shell.component';



@NgModule({
  declarations: [
    WorkspaceShellComponent
  ],
  exports: [
    WorkspaceShellComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class WorkspaceShellModule { }
