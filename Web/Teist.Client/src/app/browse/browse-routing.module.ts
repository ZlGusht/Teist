import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChartComponent } from './chart/chart.component';
import { ReviewComponent } from './review/review.component';
import { PieceComponent } from './piece/piece.component';
import { HomeComponent } from './home/home.component';

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
},{
    path: '',
    pathMatch: 'full',
    component: HomeComponent,
}
     
  ]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BrowseRoutingModule { }
