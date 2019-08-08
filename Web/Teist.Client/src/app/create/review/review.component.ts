import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent {

  public reviewForm = new FormGroup({
    name: new FormControl(''),
    targe: new FormControl(''),
    desription: new FormControl('')
  });

}
