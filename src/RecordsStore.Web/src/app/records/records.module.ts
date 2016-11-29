import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { RecordsComponent } from './records.component';
import { RecordListComponent } from './record-list/record-list.component';
import { RecordDetailComponent } from './record-detail/record-detail.component';
import { RecordSearchComponent } from './record-search/record-search.component';

import { RecordDetailResolveService } from './record-detail/record-detail-resolve.service';

import { RecordRoutingModule } from './records-routing.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        RecordRoutingModule
    ],
    declarations: [
        RecordsComponent,
        RecordListComponent,
        RecordDetailComponent,
        RecordSearchComponent
    ],
    exports: [ RecordSearchComponent ],
    providers: [ RecordDetailResolveService ]
})
export class RecordsModule { }
