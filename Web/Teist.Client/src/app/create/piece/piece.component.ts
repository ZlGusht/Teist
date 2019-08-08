import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-piece',
  templateUrl: './piece.component.html',
  styleUrls: ['./piece.component.scss']
})
export class PieceComponent {

  public pieceForm = new FormGroup({
    name: new FormControl(''),
    genre: new FormControl(''),
    album: new FormControl(''),
    performer: new FormControl(''),
    collaborators: new FormControl(''),
  });

}
