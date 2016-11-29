/* tslint:disable:no-unused-variable */

import { inject } from '@angular/core/testing';
import { Router } from '@angular/router';

import { HomeComponent } from './home.component';

import { RecordService } from '../core/records/record.service';

describe('Component: Home', () => {
    it('should create an instance', () => {
        inject([RecordService, Router], (recordService: RecordService, router: Router) => {
            let component = new HomeComponent(recordService, router);
            expect(component).toBeTruthy();
        });
    });
});

