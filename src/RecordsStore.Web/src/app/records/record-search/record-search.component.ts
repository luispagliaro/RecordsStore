import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import { RecordSearchService } from '../../core/records/record-search.service';

import { Record } from '../shared/record.model';

@Component({
    selector: 'app-record-search',
    templateUrl: './record-search.component.html',
    styleUrls: ['./record-search.component.css'],
    providers: [RecordSearchService]
})
export class RecordSearchComponent implements OnInit {
    records: Observable<Record[]>;
    // Subject is a producer of an observable event stream.
    private searchTerms = new Subject<string>();

    constructor(
        private recordSearchService: RecordSearchService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.records = this.searchTerms
            .debounceTime(300)
            .distinctUntilChanged()
            .switchMap(term => term ? this.recordSearchService.search(term) : Observable.of<Record[]>([]))
            .catch(error => {
                console.log(error);
                return Observable.of<Record[]>([]);
            });
    }

    // Push a search term into the observable stream.
    search(term: string): void {
        this.searchTerms.next(term);
    }

    goToDetail(record: Record): void {
        this.router.navigate(['/records', record.id]);
    }
}
