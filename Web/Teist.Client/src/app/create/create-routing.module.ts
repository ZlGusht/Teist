import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChartComponent } from './chart/chart.component';
import { ReviewComponent } from './review/review.component';
import { PieceComponent } from './piece/piece.component';
import { AlbumComponent } from './album/album.component';
import { ArtistComponent } from './artist/artist.component';
import { HomeComponent } from './home/home.component';

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
},{
    path: '',
    pathMatch: 'full',
    component: HomeComponent
}
  ]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateRoutingModule { }
