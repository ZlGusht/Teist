import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChartComponent } from '../create/chart/chart.component';
import { ReviewComponent } from './review/review.component';
import { PieceComponent } from './piece/piece.component';

const routes: Routes = [{
  path: 'browse',
  children: [{
    path: 'chart',
    pathMatch: 'full',
    component: ChartComponent
},{
    path: 'review',
    pathMatch: 'full',
    component: ReviewComponent
},{
    path: 'piece',
    pathMatch: 'full',
    component: PieceComponent
}
     
  ]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BrowseRoutingModule { }
