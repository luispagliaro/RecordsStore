import { Injectable } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import { Observable } from 'rxjs/Observable';

import { Record } from '../../records/shared/record.model';

@Injectable()
export class RecordService {
    private recordsUrl: string = 'http://localhost:59703/api/records';
    private headers = new RequestOptions(
        {
            headers: new Headers({ 'Content-Type': 'application/json' })
        }
    );

    constructor(private http: Http) { }

    getRecords(): Observable<Record[]> {
        return this.http.get(this.recordsUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getRecord(id: number): Observable<Record> {
        return this.getRecords()
            .map((records: Record[]) => records.find(r => r.id === id));
    }

    addRecord(title: string): Observable<Record> {
        return this.http.post(this.recordsUrl, JSON.stringify({ title }), this.headers)
            .map(this.extractData)
            .catch(this.handleError);
    }

    updateRecord(record: Record): Observable<Record> {
        const url = `${this.recordsUrl}/${record.id}`;

        return this.http.put(url, JSON.stringify(record), this.headers)
            .map(() => record)
            .catch(this.handleError);
    }

    deleteRecord(id: number): Observable<void> {
        const url = `${this.recordsUrl}/${id}`;

        return this.http.delete(url, this.headers)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();

        return body || {};
    }

    private handleError(error: any): Observable<string> {
        let errMsg: string = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';

        console.error(errMsg);

        return Observable.throw(errMsg);
    }
}
