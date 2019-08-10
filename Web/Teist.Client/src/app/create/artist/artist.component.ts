import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Genre } from 'src/app/shared/enums/genre';
import { Artist } from 'src/app/shared/models/artist';
import { ArtistDataService } from 'src/app/shared/services/data/artist-data.service';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.scss']
})
export class ArtistComponent {

  public genres = Object.keys(Genre).splice(9);

  public artistForm = new FormGroup({
    name: new FormControl(''),
    genre: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl('')
  });

  constructor(private readonly dataService: ArtistDataService){}

  public Create(){
    var artist = new Artist(this.artistForm.value);
    this.dataService.create(artist);
  }
}
