import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './components/UI/footer/footer.component';
import { HeaderComponent } from './components/UI/header/header.component';
import { MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {HttpClientModule} from "@angular/common/http";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {MatButtonToggleModule} from "@angular/material/button-toggle";
import { BaseComponent } from './components/base/base.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { ProductCardComponent } from './components/product-components/product-card/product-card.component';
import {MatCardModule} from "@angular/material/card";
import {CurrencyPipe} from "@angular/common";
import { ProductPageComponent } from './components/product-components/product-page/product-page.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    BaseComponent,
    MainPageComponent,
    ProductCardComponent,
    ProductPageComponent
  ],
    imports: [
        HttpClientModule,
        BrowserModule,
        BrowserAnimationsModule,
        MatButtonToggleModule,
        AppRoutingModule,
        MatToolbarModule,
        MatIconModule,
        MatButtonModule,
        MatCardModule,
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
