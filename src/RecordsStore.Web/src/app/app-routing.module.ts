import { NgModule } from '@angular/core';
import { RouterModule, PreloadAllModules } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

import { AuthGuard } from './core/auth/auth-guard.service';


@NgModule({
    imports: [
        RouterModule.forRoot([
            {
                path: '',
                redirectTo: 'home',
                pathMatch: 'full'
            },
            {
                path: 'home',
                component: HomeComponent
            },
            {
                path: 'records',
                loadChildren: 'app/records/records.module#RecordsModule'
            },
            {
                path: 'admin',
                loadChildren: 'app/admin/admin.module#AdminModule',
                canLoad: [AuthGuard]
            },
            {
                path: 'login',
                component: LoginComponent
            },
            {
                path: '**',
                component: PageNotFoundComponent
            },
        ],
            { preloadingStrategy: PreloadAllModules }
        )
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }