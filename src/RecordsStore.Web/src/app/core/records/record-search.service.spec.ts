/* tslint:disable:no-unused-variable */

import { Http } from '@angular/http';
import { inject } from '@angular/core/testing';

import { RecordSearchService } from './record-search.service';

describe('Service: RecordSearch', () => {

    it('should create an instance', () => {
        inject([Http], (http: Http) => {
            let service = new RecordSearchService(http);
            expect(service).toBeTruthy();
        });
    });
});
