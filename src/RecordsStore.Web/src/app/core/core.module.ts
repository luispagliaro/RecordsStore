import { NgModule, Optional, SkipSelf } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { throwIfAlreadyLoaded } from './module-import-guard';

import { NavComponent } from './nav/nav.component';

import { RecordService } from './records/record.service';
import { RecordSearchService } from './records/record-search.service';

@NgModule({
    imports: [
        CommonModule,
        RouterModule
    ],
    exports: [ NavComponent ],
    declarations: [ NavComponent ],
    providers: [
        RecordService,
        RecordSearchService
    ]
})
export class CoreModule {
    constructor(
        @Optional() @SkipSelf() parentModule: CoreModule
    ) {
        throwIfAlreadyLoaded(parentModule, 'CoreModule');
    }
}
