import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.scss']
})
export class ArtistComponent {

  public artistForm = new FormGroup({
    name: new FormControl(''),
    genre: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl('')
  });

}
