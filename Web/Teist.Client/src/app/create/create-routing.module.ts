import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChartComponent } from './chart/chart.component';
import { ReviewComponent } from '../browse/review/review.component';
import { PieceComponent } from '../browse/piece/piece.component';
import { AlbumComponent } from './album/album.component';
import { ArtistComponent } from './artist/artist.component';

const routes: Routes = [{
  path: 'create',
  children: [{
    path: 'chart',
    pathMatch: 'full',
    component: ChartComponent
},{
    path: 'piece',
    pathMatch: 'full',
    component: PieceComponent
},{
    path: 'review',
    pathMatch: 'full',
    component: ReviewComponent
},{
    path: 'album',
    pathMatch: 'full',
    component: AlbumComponent
},{
    path: 'artist',
    pathMatch: 'full',
    component: ArtistComponent
}
  ]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateRoutingModule { }
