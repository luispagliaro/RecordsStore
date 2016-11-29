/* tslint:disable:no-unused-variable */

import { Http } from '@angular/http';
import { inject } from '@angular/core/testing';

import { RecordService } from './record.service';

describe('Service: Record', () => {
    it('should create an instance', () => {
        inject([Http], (http: Http) => {
            let service = new RecordService(http);
            expect(service).toBeTruthy();
        });
    });
});
