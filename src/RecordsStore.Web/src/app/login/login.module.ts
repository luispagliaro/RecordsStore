import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';

import { LoginComponent } from './login.component';

import { AuthGuard } from '../core/auth/auth-guard.service';
import { AuthService } from '../core/auth/auth.service';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        LoginComponent
    ],
    providers: [
        AuthGuard,
        AuthService
    ]
})
export class LoginModule { }
