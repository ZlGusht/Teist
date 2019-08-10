import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {

  private review;
  private target;
  constructor(private router: Router) {
    this.review = history.state.data.review;
    if (this.review.album !== null) {
      this.target = this.review.album;
    }
    
    if (this.review.artist !== null) {
      this.target = this.review.artist;
      this.target.name = this.target.nickname;
    }
    
    if (this.review.piece !== null) {
      this.target = this.review.piece;
    }
   }

  ngOnInit() {
  }

  public goBack(){
  this.router.navigateByUrl('browse/review');
  }
}
