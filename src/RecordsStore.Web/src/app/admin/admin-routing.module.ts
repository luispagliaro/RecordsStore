import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AdminComponent } from './admin.component';
import { ManageRecordsComponent } from './manage-records/manage-records.component';
import { ManageBandsComponent } from './manage-bands/manage-bands.component';

import { AuthGuard } from '../core/auth/auth-guard.service';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AdminComponent,
                canActivate: [AuthGuard],
                children: [
                    {
                        path: '',
                        canActivateChild: [AuthGuard],
                        children: [
                            { path: '', redirectTo: 'manage-records' },
                            { path: 'manage-records', component: ManageRecordsComponent },
                            { path: 'manage-bands', component: ManageBandsComponent }
                        ]
                    }
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class AdminRoutingModule { }