/* tslint:disable:no-unused-variable */

import { inject } from '@angular/core/testing';
import { Router } from '@angular/router';

import { RecordSearchService } from '../../core/records/record-search.service';
import { RecordSearchComponent } from './record-search.component';

describe('Component: RecordSearch', () => {
    it('should create an instance', () => {
        inject([RecordSearchService, Router], (recordSearchService: RecordSearchService, router: Router) => {
            let component = new RecordSearchComponent(recordSearchService, router);
            expect(component).toBeTruthy();
        });
    });
});
