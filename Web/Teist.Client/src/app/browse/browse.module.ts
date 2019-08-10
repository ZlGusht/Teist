import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrowseRoutingModule } from './browse-routing.module';
import { ChartComponent } from './chart/chart.component';
import { PieceComponent } from './piece/piece.component';
import { ReviewComponent } from './review/review.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  imports: [
    CommonModule,
    BrowseRoutingModule
  ],
  declarations: [ChartComponent, PieceComponent, ReviewComponent, HomeComponent]
})
export class BrowseModule { }
