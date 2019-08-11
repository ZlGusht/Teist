import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ArtistDataService } from 'src/app/shared/services/data/artist-data.service';
import { PieceDataService } from 'src/app/shared/services/data/piece-data.service';
import { Piece } from 'src/app/shared/models/piece';
import { Genre } from 'src/app/shared/enums/genre';
import { PieceType } from 'src/app/shared/enums/pieceType';
import { Router } from '@angular/router';

@Component({
  selector: 'app-piece',
  templateUrl: './piece.component.html',
  styleUrls: ['./piece.component.scss']
})
export class PieceComponent implements OnInit {

  public artists;

  private isEdit = false;

  public genres = Object.keys(Genre).splice(9);

  public pieceTypes = Object.keys(PieceType).splice(7);

  public dropdownSettings = {
    singleSelection: false,
    idField: 'id',
    textField: 'nickname',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 10,
    allowSearchFilter: true
  };

  public single = {
    singleSelection: true,
    idField: 'id',
    textField: 'nickname',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 10,
    allowSearchFilter: true
  };

  public pieceForm = new FormGroup({
    name: new FormControl(''),
    genre: new FormControl(''),
    pieceType: new FormControl(''),
    performer: new FormControl(''),
  });

  constructor(private artistDataService: ArtistDataService, private pieceDataService: PieceDataService, private router: Router) {}

  ngOnInit(): void {
  this.artistDataService.getAll().then(artists => {
    this.artists = artists;
  })

  if (history.state.data.piece) {
    this.pieceForm.controls.name.setValue(history.state.data.piece.name);
    this.pieceForm.controls.genre.setValue(history.state.data.piece.genre);
    this.pieceForm.controls.pieceType.setValue(history.state.data.piece.pieceType);
    this.pieceForm.controls.performer.setValue([{id: history.state.data.piece.id, nickname: history.state.data.piece.artist.nickname}]);
    this.isEdit = true;
  }

  }

  public Create(){
    const performer = this.pieceForm.value.performer[0].nickname;
    
    const piece = {name: this.pieceForm.value.name, genre: this.pieceForm.value.genre, pieceType: this.pieceForm.value.pieceType}
    const data = new Piece(piece, performer);
    
    this.pieceDataService.create(data).then(() => {
      this.router.navigateByUrl('browse/piece');
    });
  }

  public UpdateEntity(){
    const performer = this.pieceForm.value.performer[0].nickname;
    
    const piece = {name: this.pieceForm.value.name, genre: this.pieceForm.value.genre, pieceType: this.pieceForm.value.pieceType}
    const data = new Piece(piece, performer);

    this.pieceDataService.update(history.state.data.piece.name, data).then(() => {
      history.state.data.piece = undefined;
      this.router.navigateByUrl('browse/piece');
    });
    
  }
}
