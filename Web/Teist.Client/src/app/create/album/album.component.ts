import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AlbumDataService } from 'src/app/shared/services/data/album-data.service';
import { Album } from 'src/app/shared/models/album';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.scss']
})
export class AlbumComponent {

  constructor(private dataService: AlbumDataService) {
  }
  public albumForm = new FormGroup({
    name: new FormControl(''),
    genre: new FormControl(''),
    pieces: new FormControl(''),
    performer: new FormControl(''),
    collaborators: new FormControl(''),
  });

  public Create() {
    this.dataService.create(this.CreateModel(this.albumForm.value));
  }

  private CreateModel(album: any): Album {
    const performer = album.value.performer.Split(',');
    return new Album(album);
  }
}
