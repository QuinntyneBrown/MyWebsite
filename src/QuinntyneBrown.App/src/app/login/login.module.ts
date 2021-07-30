import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { UsernameFormComponent } from './username-form/username-form.component';
import { PasswordFormComponent } from './password-form/password-form.component';
import { RememberMeComponent } from './remember-me/remember-me.component';

@NgModule({
  declarations: [
    LoginComponent,
    LoginFormComponent,
    UsernameFormComponent,
    PasswordFormComponent,
    RememberMeComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule
  ]
})
export class LoginModule { }
