/* tslint:disable:no-unused-variable */

import { inject } from '@angular/core/testing';
import { Router } from '@angular/router';

import { RecordService } from '../../core/records/record.service';
import { AuthService } from '../../core/auth/auth.service';


import { RecordListComponent } from './record-list.component';

describe('Component: RecordList', () => {
    it('should create an instance', () => {
        inject([RecordService, Router], (recordService: RecordService, router: Router, authService: AuthService) => {
            let component = new RecordListComponent(recordService, router, authService);
            expect(component).toBeTruthy();
        });
    });
});
