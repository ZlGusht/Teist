import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.scss']
})
export class AlbumComponent {

  public pieceForm = new FormGroup({
    name: new FormControl(''),
    genre: new FormControl(''),
    pieces: new FormControl(''),
    performer: new FormControl(''),
    collaborators: new FormControl(''),
  });

}
