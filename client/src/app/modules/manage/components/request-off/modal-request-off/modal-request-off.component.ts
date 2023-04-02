import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { OptionOnLeave, Status } from 'src/app/enums/Enum';
import { LoginResponse } from 'src/app/interfaces/interfaceReponse';
import { DataService } from 'src/app/services/data.service';
import { ManageService } from '../../../services/manage.service';

@Component({
  selector: 'app-modal-request-off',
  templateUrl: './modal-request-off.component.html',
  styleUrls: ['./modal-request-off.component.css']
})
export class ModalRequestOffComponent implements OnInit, OnChanges {
  @Input() isVisibleModal: boolean = false;
  @Input() requestList: { date: Date, option: OptionOnLeave, status: Status }[] = [];
  @Output() cancel: EventEmitter<boolean> = new EventEmitter();
  @Output() submit: EventEmitter<boolean> = new EventEmitter();
  requestOnLeaveForm!: FormGroup;
  user!: LoginResponse;

  constructor(
    private manageService: ManageService,
    private dataService: DataService,
    private notification: NzNotificationService,
    private fb: FormBuilder,
  ){}

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('user') || sessionStorage.getItem('user') || '{}');
    this.requestOnLeaveForm = this.fb.group({
      employeeId: [this.user.id],
      onLeave: this.fb.array([]),
    })
  }
  
  ngOnChanges(): void {
    this.requestList.sort((a,b) => {
      return new Date(a.date).getTime() - new Date(b.date).getTime();
    })
  }

  handleCancel(){
    this.cancel.emit();
  }

  getNameOptionLeave(option: OptionOnLeave){
    let name!: { value: OptionOnLeave; label: string};
    this.dataService.requestOffList
      .subscribe((data: { value: OptionOnLeave; label: string}[]) => {
        name = data.find(d => d.value == option)!;
      });
    return name.label;
  }

  handleSubmit(){
    (this.requestOnLeaveForm.controls['onLeave'] as FormArray).clear();
    if((<HTMLInputElement>document.getElementById('reason')).value == ''){
      this.notification.warning('You must input reason!!!','');
    } else {
      this.requestList.forEach((item) => {
        const onleaveItemForm = this.fb.group({
          dateLeave: new Date((item.date as Date).setHours(7)),
          option: item.option,
          reason: (<HTMLInputElement>document.getElementById('reason')).value,
        });
        (this.requestOnLeaveForm.controls['onLeave'] as FormArray).push(onleaveItemForm);
      });
      this.manageService.requestOnLeave(this.requestOnLeaveForm.value);
      this.submit.emit();
    }
  }
}
