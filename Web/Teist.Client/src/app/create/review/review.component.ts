import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { PieceDataService } from 'src/app/shared/services/data/piece-data.service';
import { AlbumDataService } from 'src/app/shared/services/data/album-data.service';
import { ArtistDataService } from 'src/app/shared/services/data/artist-data.service';
import { Type } from 'src/app/shared/enums/type';
import { ReviewDataService } from 'src/app/shared/services/data/review-data.service';
import { Review } from 'src/app/shared/models/review';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent {

  private piece = history.state.data;

  public reviewForm = new FormGroup({
    name: new FormControl(''),
    target: new FormControl(''),
    type: new FormControl(''),
    description: new FormControl('')
  });



  public types = Object.keys(Type).splice(3);

  public artists;
  public pieces;
  public albums;

  public albumSettings = {
    singleSelection: true,
    idField: 'id',
    textField: 'name',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 10,
    allowSearchFilter: true
  };

  public artistSettings = {
    singleSelection: true,
    idField: 'id',
    textField: 'nickname',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 10,
    allowSearchFilter: true
  };

  public pieceSettings = {
    singleSelection: true,
    idField: 'id',
    textField: 'name',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 10,
    allowSearchFilter: true
  };

  constructor(private reviewService: ReviewDataService,
    private pieceService: PieceDataService,
    private albumService: AlbumDataService,
    private artistService: ArtistDataService) {

  }

  ngOnInit(): void {
    this.pieceService.getAll().then(pieces => {
      this.pieces = pieces;
    });
    this.albumService.getAll().then(albums => {
      this.albums = albums;
    });
    this.artistService.getAll().then(artists => {
      this.artists = artists;
    });
    
    if (history.state.data) {
      this.reviewForm.controls.type.setValue('Piece');
      this.reviewForm.controls.target.setValue([{id: history.state.data.piece.id, name: history.state.data.piece.name}]);
    }
  }

  public Create() {
    let target;
    if(this.reviewForm.value.type == 'Artist'){
    target = this.reviewForm.value.target[0].nickname
    } else {
      target = this.reviewForm.value.target[0].name
    }
    var review = {
      name: this.reviewForm.value.name,
      contents: target,
      type: this.reviewForm.value.type,
      description: this.reviewForm.value.description,
    }

    var data = new Review(review);
    this.reviewService.create(data);
    history.state.data = undefined;
  }

  public OnSelect(event: any) {
    this.reviewForm.controls.target.reset();
  }

}
