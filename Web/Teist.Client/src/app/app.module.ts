import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './sections/app.component';
import { HeaderComponent } from './sections/header/header.component';
import { FooterComponent } from './sections/footer/footer.component';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { HomeModule } from './home/home.module';
import { AuthenticationModule } from './authentication/authentication.module';
import { BrowseModule } from './browse/browse.module';
import { CreateModule } from './create/create.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatRadioModule } from '@angular/material/radio';
import { DisplayModule } from './display/display.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    HomeModule,
    AuthenticationModule,
    BrowseModule,
    CreateModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatAutocompleteModule,
    MatRadioModule,
    DisplayModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
