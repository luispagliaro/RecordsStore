/* tslint:disable:no-unused-variable */

import { inject } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { RecordService } from '../../core/records/record.service';
import { AuthService } from '../../core/auth/auth.service';

import { RecordDetailComponent } from './record-detail.component';

describe('Component: RecordDetail', () => {
    it('should create an instance', () => {
        inject([RecordService, Location, ActivatedRoute], (recordService: RecordService, route: ActivatedRoute, location: Location, authService: AuthService) => {
            let component = new RecordDetailComponent(recordService, route, location, authService);
            expect(component).toBeTruthy();
        });
    });
});
