import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PieceComponent } from './piece/piece.component';
import { ChartComponent } from './chart/chart.component';
import { ReviewComponent } from './review/review.component';

const routes: Routes = [
  {
    path: 'display',
    children: [
      {
        path: 'piece',
        component: PieceComponent,
        pathMatch: 'full'
      },
      {
        path: 'chart',
        component: ChartComponent,
        pathMatch: 'full'
      },
      {
        path: 'review',
        component: ReviewComponent,
        pathMatch: 'full'
      }
    ]
  }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DisplayRoutingModule { }
