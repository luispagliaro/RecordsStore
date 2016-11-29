import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminComponent } from './admin.component';
import { ManageRecordsComponent } from './manage-records/manage-records.component';
import { ManageBandsComponent } from './manage-bands/manage-bands.component';

import { AdminRoutingModule } from './admin-routing.module';

@NgModule({
    imports: [
        CommonModule,
        AdminRoutingModule
    ],
    declarations: [AdminComponent, ManageRecordsComponent, ManageBandsComponent]
})
export class AdminModule { }
