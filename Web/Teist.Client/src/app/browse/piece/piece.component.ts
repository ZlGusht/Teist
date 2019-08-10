import { Component, OnInit } from '@angular/core';
import { PieceDataService } from 'src/app/shared/services/data/piece-data.service';
import { TokenService } from 'src/app/shared/services/token/token.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-piece',
  templateUrl: './piece.component.html',
  styleUrls: ['./piece.component.scss']
})
export class PieceComponent implements OnInit {
  
  public pieces;
  constructor(private pieceService: PieceDataService, private tokenService: TokenService, private router: Router) { }

  ngOnInit() {
    this.pieceService.getAll().then(pieces => {
      this.pieces = pieces;
    })
  }
  
  public isLogged(){
    return this.tokenService.isLoggedIn;
  }

  public createReview(piece: any){
  this.router.navigateByUrl('/create/review', {state: {data: {piece: piece}}});
  }

  displayPiece(piece){
    this.router.navigateByUrl('/display/piece', {state: {data: {piece: piece}}});
  }
}
