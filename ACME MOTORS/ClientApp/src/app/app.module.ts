import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ManufactureComponent } from './manufacture/manufacture.component';
import { EngineComponent } from './engine/engine.component';
import { CarComponent } from './car/car.component';
import { TruckComponent } from './truck/truck.component';
import { MotorbikeComponent } from './motorbike/motorbike.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ManufactureComponent,
    EngineComponent,
    CarComponent,
    TruckComponent,
    MotorbikeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'engine', component: EngineComponent },
      { path: 'manu', component: ManufactureComponent },
      { path: 'car', component: CarComponent },
      { path: 'truck', component: TruckComponent },
      { path: 'motorbike', component: MotorbikeComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
