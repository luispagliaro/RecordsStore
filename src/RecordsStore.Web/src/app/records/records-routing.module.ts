import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RecordsComponent } from './records.component';
import { RecordListComponent } from './record-list/record-list.component';
import { RecordDetailComponent } from './record-detail/record-detail.component';

import { RecordDetailResolveService } from './record-detail/record-detail-resolve.service';

@NgModule({
    imports: [RouterModule.forChild([
        {
            path: '',
            component: RecordsComponent,
            children: [
                {
                    path: ':id',
                    component: RecordDetailComponent,
                    resolve: {
                        record: RecordDetailResolveService
                    }
                },
                {
                    path: '',
                    component: RecordListComponent
                }
            ]
        }
    ])
    ],
    exports: [RouterModule]
})
export class RecordRoutingModule { }