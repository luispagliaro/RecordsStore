import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';

import { RecordService } from '../../core/records/record.service';
import { Record } from '../shared/record.model';

import { Observable } from 'rxjs';

@Injectable()
export class RecordDetailResolveService implements Resolve<Record> {
    constructor(private recordService: RecordService, private router: Router) { }

    resolve(route: ActivatedRouteSnapshot): Observable<Record | boolean> {
        let id = +route.params['id'];

        return this.recordService.getRecord(id)
            .map((r: Record) => {
                if (r) {
                    return r;
                } else {
                    this.router.navigate(['/records']);

                    return false;
                }
            });
    }
}
