import { BrowserModule } from '@angular/platform-browser';
import {RouterModule} from '@angular/router';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { environment } from './../environments/environment';
import { AppComponent } from './app.component';

import { AppNavbarComponent } from './app-navbar/app-navbar.component';
import { OwnersComponent } from './owners/owners.component'; 
import { CarsComponent } from './cars/cars.component'; 

import { CarsService } from './services/cars.service'; 
import { OwnersService } from './services/owners.service'; 

@NgModule({
  declarations: [
    AppComponent,
    AppNavbarComponent,
    OwnersComponent,
    CarsComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    RouterModule.forRoot([
      { path: 'owners', component: OwnersComponent },
      { path: 'cars', component: CarsComponent },
      { path: '', redirectTo: 'owners', pathMatch: 'full'},
      { path: '**', redirectTo: 'owners', pathMatch: 'full'}
    ])
  ],
  providers: [CarsService, OwnersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
