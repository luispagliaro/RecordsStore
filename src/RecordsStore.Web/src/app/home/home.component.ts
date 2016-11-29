import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Record } from '../records/shared/record.model';

import { RecordService } from '../core/records/record.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    records: Record[];

    constructor(
        private recordService: RecordService,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.getRecords();
    }

    getRecords(): void {
        this.recordService.getRecords()
            .subscribe(records => this.records = records.slice(1, 4));
    }

    goToDetail(record: Record): void {
        this.router.navigate(['/records', record.id]);
    }
}
