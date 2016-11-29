import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Record } from '../shared/record.model';

import { RecordService } from '../../core/records/record.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
    selector: 'app-records',
    templateUrl: './record-list.component.html',
    styleUrls: ['./record-list.component.css']
})
export class RecordListComponent implements OnInit {
    records: Record[];
    selectedRecord: Record;
    errorMessage: string;
    private loggedIn: boolean;

    constructor(
        private recordService: RecordService,
        private router: Router,
        private authService: AuthService
    ) { }

    ngOnInit(): void {
        this.getRecords();

        this.loggedIn = this.authService.isLoggedIn;
    }

    onSelect(record: Record): void {
        this.selectedRecord = record;
    }

    getRecords(): void {
        this.recordService.getRecords()
            .subscribe(
                records => this.records = records,
                error => this.errorMessage = <any>error
            );
    }

    addRecord(title: string): void {
        title = title.trim();

        if (!title) { return; }

        this.recordService.addRecord(title)
            .subscribe(
                record => this.records.push(record),
                error => this.errorMessage = <any>error
            );
    }

    deleteRecord(record: Record): void {
        this.recordService
            .deleteRecord(record.id)
            .subscribe(() => {
                this.records = this.records.filter(r => r !== record);

                if (this.selectedRecord === record) {
                    this.selectedRecord = null;
                }
            });
    }

    goToDetail(record: Record): void {
        this.router.navigate(['/records', record.id]);
    }
}
