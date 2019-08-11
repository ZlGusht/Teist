import { Component, OnInit } from '@angular/core';
import { Genre } from 'src/app/shared/enums/genre';
import { PieceType } from 'src/app/shared/enums/pieceType';
import { Router } from '@angular/router';
import { PieceDataService } from 'src/app/shared/services/data/piece-data.service';

@Component({
  selector: 'app-piece',
  templateUrl: './piece.component.html',
  styleUrls: ['./piece.component.scss']
})
export class PieceComponent implements OnInit {

  private piece;
  constructor(private router: Router, private pieceService: PieceDataService) { }

  ngOnInit() {
    this.piece = history.state.data.piece;
    this.piece.genre = Genre[this.piece.genre];
    this.piece.pieceType = PieceType[this.piece.pieceType];
  }

  public goBack(){
  this.router.navigateByUrl('browse/piece');
  }

  public Delete(piece: any){
    this.pieceService.delete(piece.name);
    this.goBack();
  }

  public Update(piece: any){
    this.router.navigateByUrl('create/piece', {state: {data: {piece: piece}}});
  }

}
