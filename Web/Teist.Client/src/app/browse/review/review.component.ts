import { Component, OnInit } from '@angular/core';
import { ReviewDataService } from 'src/app/shared/services/data/review-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {
  private reviews;
  constructor(private reviewervice: ReviewDataService, private router: Router) { }

  ngOnInit() {
    this.reviewervice.getAll().then(review => {
      this.reviews = review;
    })
  }

  public displayReview(review){
    this.router.navigateByUrl('/display/review', {state: {data: {review: review}}});
  }

}
