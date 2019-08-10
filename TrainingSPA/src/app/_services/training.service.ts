import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Training } from '../_models/training';
import { map } from 'rxjs/operators';

@Injectable()
export class TrainingService {

    baseUrl = environment.apiUrl + 'training/';

    constructor(private http: HttpClient) { }

    addTraining(model: any) {
        return this.http.post(this.baseUrl, model)
        .pipe(
            map((response: any) => {
              const training = response;
              if (training) {
                  console.log(training);
                }
            })
          );
      }

}
