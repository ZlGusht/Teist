import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ChartDataService } from 'src/app/shared/services/data/chart-data.service';
import { PieceDataService } from 'src/app/shared/services/data/piece-data.service';
import { AlbumDataService } from 'src/app/shared/services/data/album-data.service';
import { ArtistDataService } from 'src/app/shared/services/data/artist-data.service';
import { Type } from 'src/app/shared/enums/type';
import { Chart } from 'src/app/shared/models/chart';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent {

  public types = Object.keys(Type).splice(3);

  public artists;
  public pieces;
  public albums;

  public albumSettings = {
    singleSelection: false,
    idField: 'id',
    textField: 'name',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 10,
    allowSearchFilter: true
  };

  public artistSettings = {
    singleSelection: false,
    idField: 'id',
    textField: 'nickname',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 10,
    allowSearchFilter: true
  };

  public pieceSettings = {
    singleSelection: false,
    idField: 'id',
    textField: 'name',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 10,
    allowSearchFilter: true
  };

  public chartForm = new FormGroup({
    name: new FormControl(''),
    type: new FormControl(''),
    description: new FormControl(''),
    contents: new FormControl(''),
  });

  constructor(private chartService: ChartDataService,
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
  }

  public Create() {
    let contents = [];
    if (this.chartForm.value.type === 'Artist') {
      this.chartForm.value.contents.forEach((content, index) => {
        contents[index] = content.nickname;
      });
    } else {
      this.chartForm.value.contents.forEach((content, index) => {
        contents[index] = content.name;
      });
    }

    let chart = {
      name: this.chartForm.value.name,
      description: this.chartForm.value.description,
      type: this.chartForm.value.type,
      contents: contents
    };
    var data = new Chart(chart);

    this.chartService.create(data);
  }

  public OnSelect(event: any) {
    this.chartForm.controls.contents.reset();
  }
}
