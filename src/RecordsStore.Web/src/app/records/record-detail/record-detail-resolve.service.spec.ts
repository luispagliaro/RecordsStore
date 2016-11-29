/* tslint:disable:no-unused-variable */

import { inject } from '@angular/core/testing';
import { Router } from '@angular/router';

import { RecordService } from '../../core/records/record.service';
import { RecordDetailResolveService } from './record-detail-resolve.service';

describe('Service: RecordDetailResolve', () => {
    it('should ...', () => {
        inject([Router, RecordService], (recordService: RecordService, router: Router) => {
            let service = new RecordDetailResolveService(recordService, router);
            expect(service).toBeTruthy();
        });
    });
});
