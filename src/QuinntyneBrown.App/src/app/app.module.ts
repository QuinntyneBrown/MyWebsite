import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { baseUrl } from '@core';
import { ShellModule } from '@shared/shells/shell';
import { WorkspaceShellModule } from '@shared/shells/workspace-shell';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ShellModule,
    WorkspaceShellModule,
    HttpClientModule
  ],
  providers: [
    { provide: baseUrl, useValue: "https://localhost:5001/"}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
