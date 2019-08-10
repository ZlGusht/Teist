import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ArtistDataService } from 'src/app/shared/services/data/artist-data.service';
import { PieceDataService } from 'src/app/shared/services/data/piece-data.service';
import { Piece } from 'src/app/shared/models/piece';
import { Genre } from 'src/app/shared/enums/genre';
import { PieceType } from 'src/app/shared/enums/pieceType';

@Component({
  selector: 'app-piece',
  templateUrl: './piece.component.html',
  styleUrls: ['./piece.component.scss']
})
export class PieceComponent implements OnInit {

  public artists;

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
    collaborators: new FormControl(''),
  });

  constructor(private artistDataService: ArtistDataService, private pieceDataService: PieceDataService) {}

  ngOnInit(): void {
  this.artistDataService.getAll().then(artists => {
    this.artists = artists;
  })

  }

  public Create(){
    const performer = this.pieceForm.value.performer[0].nickname;
    let collaborators = [];
    if (this.pieceForm.value.collaborators != '')
     {this.pieceForm.value.collaborators.forEach((collab, index) => {
      collaborators[index] = collab.nickname;
    });
    }
    
    const piece = {name: this.pieceForm.value.name, genre: this.pieceForm.value.genre, pieceType: this.pieceForm.value.pieceType}
    const data = new Piece(piece, performer, collaborators);
    
    this.pieceDataService.create(data);
  }
}
