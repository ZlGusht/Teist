import { Component, OnInit } from '@angular/core';
import { TokenService } from 'src/app/shared/services/token/token.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  constructor(private readonly tokenService: TokenService) {
  }

  public isLoggedIn(): boolean {
    return this.tokenService.isLoggedIn;
  }

  public LogOut() {
    this.tokenService.removeToken();
  }
}
