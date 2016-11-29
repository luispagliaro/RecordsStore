import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs';

import { Record } from '../../records/shared/record.model';

@Injectable()
export class RecordSearchService {
    constructor(private http: Http) { }

    search(term: string): Observable<Record[]> {
        return this.http.get(`http://localhost:59703/api/records/?recordTitle=${term}`)
            .map((r: Response) => r.json() as Record[]);
    }
}
