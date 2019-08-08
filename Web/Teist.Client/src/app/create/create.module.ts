import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateRoutingModule } from './create-routing.module';
import { ChartComponent } from './chart/chart.component';
import { PieceComponent } from './piece/piece.component';
import { ReviewComponent } from './review/review.component';
import { AlbumComponent } from './album/album.component';
import { ArtistComponent } from './artist/artist.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatRadioModule } from '@angular/material/radio';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material';

@NgModule({
  imports: [
    CommonModule,
    CreateRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatRadioModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule
  ],
  declarations: [ChartComponent, PieceComponent, ReviewComponent, AlbumComponent, ArtistComponent]
})
export class CreateModule { }
