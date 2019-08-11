import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from 'src/app/shared/services/token/token.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent{
  public userName;
  constructor(private router: Router, private tokenService: TokenService)
   {
     this.userName = tokenService.userName;
    }
  
  public Browse(){
    this.router.navigateByUrl('browse')
  }

  public Create(){
    this.router.navigateByUrl('create');
  }
}
