import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/shared/services/authentication/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  /**
   *
   */
  constructor(private authService: AuthenticationService) {
  }

public login = new FormGroup({
  email: new FormControl('', [
  Validators.required,
  Validators.email]),
  password: new FormControl('', [
    Validators.required,
    Validators.minLength(5)])
});

public LogIn() {
  this.authService.LogIn(this.login.value);
}

}
