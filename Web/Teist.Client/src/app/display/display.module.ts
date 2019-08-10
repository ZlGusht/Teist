import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DisplayRoutingModule } from './display-routing.module';
import { PieceComponent } from './piece/piece.component';
import { ReviewComponent } from './review/review.component';
import { ChartComponent } from './chart/chart.component';

@NgModule({
  declarations: [PieceComponent, ReviewComponent, ChartComponent],
  imports: [
    CommonModule,
    DisplayRoutingModule
  ]
})
export class DisplayModule { }
