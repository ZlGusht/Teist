import { Component, OnInit } from '@angular/core';
import { ChartDataService } from 'src/app/shared/services/data/chart-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {

  private charts;
  constructor(private chartService: ChartDataService, private router: Router) { }

  ngOnInit() {
    this.chartService.getAll().then(charts => {
      this.charts = charts;
    })
  }

  public displayChart(chart){
    this.router.navigateByUrl('/display/chart', {state: {data: {chart: chart}}});
  }

}
