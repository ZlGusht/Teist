import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateRoutingModule } from './create-routing.module';
import { ChartComponent } from './chart/chart.component';
import { PieceComponent } from './piece/piece.component';
import { ReviewComponent } from './review/review.component';
import { AlbumComponent } from './album/album.component';
import { ArtistComponent } from './artist/artist.component';

@NgModule({
  imports: [
    CommonModule,
    CreateRoutingModule
  ],
  declarations: [ChartComponent, PieceComponent, ReviewComponent, AlbumComponent, ArtistComponent]
})
export class CreateModule { }
