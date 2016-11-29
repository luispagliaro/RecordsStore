import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Record } from '../shared/record.model';

import { RecordService } from '../../core/records/record.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
    selector: 'app-record-detail',
    templateUrl: './record-detail.component.html',
    styleUrls: ['./record-detail.component.css']
})
export class RecordDetailComponent implements OnInit {
    private record: Record;
    private loggedIn: boolean;

    constructor(
        private recordService: RecordService,
        private route: ActivatedRoute,
        private location: Location,
        private authService: AuthService
    ) { }

    ngOnInit() {
        this.route.data.forEach((data: { record: Record }) => {
            this.record = data.record;
        });

        this.loggedIn = this.authService.isLoggedIn;
        /*this.route.params.forEach((params: Params) => {
            let id = +params['id'];

            this.recordService.getRecord(id)
                .subscribe((r: Record) => this.record = r);
        });*/
    }

    updateRecord(): void {
        this.recordService.updateRecord(this.record)
            .subscribe(() => this.goBack());
    }

    goBack(): void {
        this.location.back();
    }
}
