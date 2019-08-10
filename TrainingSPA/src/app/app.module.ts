import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BsDatepickerModule } from 'ngx-bootstrap';
import { AppComponent } from './app.component';
import { TrainingComponent } from './training/training.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TrainingService } from './_services/training.service';
import { HttpClientModule } from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

@NgModule({
   declarations: [
      AppComponent,
      TrainingComponent
   ],
   imports: [
      BrowserModule,
      FormsModule,
      ReactiveFormsModule,
      BsDatepickerModule.forRoot(),
      HttpClientModule,
      BrowserAnimationsModule
   ],
   providers: [
      TrainingService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
