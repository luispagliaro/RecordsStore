/* tslint:disable:no-unused-variable */

import { inject } from '@angular/core/testing';
import { Router } from '@angular/router';

import { LoginComponent } from './login.component';

import { AuthService } from '../core/auth/auth.service';

describe('Component: Login', () => {
    it('should create an instance', () => {
        inject([Router, AuthService], (authService: AuthService, router: Router) => {
            let component = new LoginComponent(authService, router);
            expect(component).toBeTruthy();
        });
    });
});
