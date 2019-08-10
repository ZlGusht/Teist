import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/shared/services/authentication/authentication.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  constructor(private authenticationService: AuthenticationService, private router: Router) {
  }

  public inputs = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.email]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(5)]),
    passwordConfirmation: new FormControl('', [
      Validators.required,
      Validators.minLength(5)]),
  });

  public Register() {
  this.authenticationService.Register(this.inputs.value).subscribe(
    () => { },
    (error: HttpErrorResponse) => {});

    this.router.navigate(['/home']);
  }
  

}
