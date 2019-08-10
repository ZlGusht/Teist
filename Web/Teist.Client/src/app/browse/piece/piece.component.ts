import { Component, OnInit } from '@angular/core';
import { PieceDataService } from 'src/app/shared/services/data/piece-data.service';

@Component({
  selector: 'app-piece',
  templateUrl: './piece.component.html',
  styleUrls: ['./piece.component.scss']
})
export class PieceComponent implements OnInit {

  public pieces;
  constructor(private pieceService: PieceDataService) { }

  ngOnInit() {
    this.pieceService.getAll().then(pieces => {
      this.pieces = pieces;
    })
  }

}
