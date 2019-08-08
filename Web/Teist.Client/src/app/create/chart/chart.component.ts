import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent {
  public chartForm = new FormGroup({
    name: new FormControl(''),
    type: new FormControl('Song'),
    description: new FormControl(''),
    contents: new FormControl(''),
  });

  public contents: string[] = null;
}
