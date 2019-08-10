import { Component, OnInit } from '@angular/core';
import { Genre } from 'src/app/shared/enums/genre';
import { PieceType } from 'src/app/shared/enums/pieceType';
import { Router } from '@angular/router';

@Component({
  selector: 'app-piece',
  templateUrl: './piece.component.html',
  styleUrls: ['./piece.component.scss']
})
export class PieceComponent implements OnInit {

  private piece;
  constructor(private router: Router) { }

  ngOnInit() {
    this.piece = history.state.data.piece;
    this.piece.genre = Genre[this.piece.genre];
    this.piece.pieceType = PieceType[this.piece.pieceType];
  }

  public goBack(){
  this.router.navigateByUrl('browse/piece');
  }

}
