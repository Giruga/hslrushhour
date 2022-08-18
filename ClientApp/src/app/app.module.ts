import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { DisruptionsComponent } from './components/disruptions/disruptions.component';
import { AppRoutingModule } from './app.routing.module';
import { StructuralModule } from './structural/structural.module';

@NgModule({
  declarations: [AppComponent, HomeComponent, DisruptionsComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    MatTableModule,
    StructuralModule,
    AppRoutingModule
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
