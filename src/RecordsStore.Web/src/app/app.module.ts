import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';

import { InMemoryWebApiModule } from 'angular-in-memory-web-api/in-memory-web-api.module';
import { InMemoryDataService } from './core/in-memory-data.service';
import './rxjs-extensions';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

import { CoreModule } from './core/core.module';
import { LoginModule }   from './login/login.module';

import { AppRoutingModule } from './app-routing.module';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        //InMemoryWebApiModule.forRoot(InMemoryDataService),
        CoreModule,
        AppRoutingModule,
        LoginModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        PageNotFoundComponent
    ],
    bootstrap: [ AppComponent ]
})
export class AppModule { }
