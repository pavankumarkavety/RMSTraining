import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TrainingService } from '../_services/training.service';
import { AlertifyService } from '../_services/alertify.service';
import { FormGroup, FormControl, Validators, FormBuilder, NgForm } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { Training } from '../_models/training';


@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.css']
})
export class TrainingComponent implements OnInit {
  trainingForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  training: Training;
  showMyMessage = false;
  noofdays = 0;
  constructor(public trainingService: TrainingService,  private alertify: AlertifyService, private fb: FormBuilder ) { }

  ngOnInit() {
    this.createTrainingForm();
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  createTrainingForm() {
    this.trainingForm = this.fb.group({
      name: ['', Validators.required],
      startdate: [null, Validators.required],
      enddate: [null, Validators.required]
    },  {validator: this.compareTwoDates});
  }

  // dateValidator(g: FormGroup) {
  //   return g.get('startdate').value >= g.get('enddate').value ? null : {mismatch: true};
  // }

  compareTwoDates(g: FormGroup){
    // if(new Date(g.get('enddate').value)<new Date(g.get('startdate').value )){
    //    this.error={isError:true,errorMessage:'End Date can not be before start date'};
    // }
    return new Date(g.get('startdate').value) < new Date(g.get('enddate').value) ? null : {error: true};
 }

 getDifference(sDate: Date, eDate: Date) {
  var oneDay = 24*60*60*1000; // hours*minutes*seconds*milliseconds    
    var diffDays = Math.round(Math.abs((eDate.getTime() - sDate.getTime())/(oneDay)));
  return diffDays;
 }

  addTraining(form?: NgForm) {
    if (this.trainingForm.valid) {
      this.training = Object.assign({}, this.trainingForm.value);
      this.trainingService.addTraining(this.training).subscribe(next => {
        form.reset();
        this.showMyMessage = true;
        this.noofdays = this.getDifference(this.training.startdate, this.training.enddate);
        this.alertify.success('Training submitted successful');
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    
  }

}
