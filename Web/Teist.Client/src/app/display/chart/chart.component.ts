import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Genre } from 'src/app/shared/enums/genre';
import { Type } from 'src/app/shared/enums/type';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {

  private chart;
  constructor(private router: Router) { }

  ngOnInit() {
    this.chart = history.state.data.chart;
    this.chart.genre = Genre[this.chart.genre];
    this.chart.chartType = Type[this.chart.chartType];
  }

  public goBack(){
  this.router.navigateByUrl('browse/chart');
  }

}
