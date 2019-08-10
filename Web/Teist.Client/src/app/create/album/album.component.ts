import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AlbumDataService } from 'src/app/shared/services/data/album-data.service';
import { Album } from 'src/app/shared/models/album';
import { Genre } from 'src/app/shared/enums/genre';
import { PieceDataService } from 'src/app/shared/services/data/piece-data.service';
import { ArtistDataService } from 'src/app/shared/services/data/artist-data.service';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.scss']
})
export class AlbumComponent {

  public genres = Object.keys(Genre).splice(9);

  public artists;

  public pieces;

  public dropdownSettings = {
    singleSelection: false,
    idField: 'id',
    textField: 'nickname',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 10,
    allowSearchFilter: true
  };

  public dropdownSettingsSingle = {
    singleSelection: true,
    idField: 'id',
    textField: 'nickname',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 10,
    allowSearchFilter: true
  };
  
  public dropdownSettingsPieces = {
    singleSelection: false,
    idField: 'id',
    textField: 'name',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 10,
    allowSearchFilter: true
  };

  public albumForm = new FormGroup({
    name: new FormControl(''),
    genre: new FormControl(''),
    pieces: new FormControl(''),
    performer: new FormControl('')
  });

  constructor(private dataService: AlbumDataService,
    private artistDataService: ArtistDataService, private pieceDataService: PieceDataService) {
  }


  ngOnInit(): void {
    this.artistDataService.getAll().then(artists => {
      this.artists = artists;
    })

    this.pieceDataService.getAll().then(pieces => {
      this.pieces = pieces;
    })
  }
  public Create() {
    let album;
    let pieces = [];
    this.albumForm.value.pieces.forEach((piece, index) => {
      pieces[index] = piece.name;
    });
    const performer = this.albumForm.value.performer[0].nickname;

    album = {
      name: this.albumForm.value.name,
      genre: this.albumForm.value.genre,
      pieces: pieces,
      performer: performer,
    };

    const data = new Album(album);

    this.dataService.create(data);
  }
}
