import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { OptionOnLeave, Status } from 'src/app/enums/Enum';
import { DataService } from 'src/app/services/data.service';
import { OnleaveService } from 'src/app/services/onleave.service';

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

  constructor(
    private onleaveService: OnleaveService,
    private dataService: DataService,
    private notification: NzNotificationService,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    const user = JSON.parse(localStorage.getItem('user') || sessionStorage.getItem('user') || '{}');
    this.requestOnLeaveForm = this.fb.group({
      employeeId: [user.id],
      onLeave: this.fb.array([]),
    })
  }

  ngOnChanges(): void {
    this.requestList.sort((a, b) => {
      return new Date(a.date).getTime() - new Date(b.date).getTime();
    })
  }

  handleCancel() {
    this.cancel.emit();
  }

  getNameOptionLeave(option: OptionOnLeave) {
    let name!: { value: OptionOnLeave; label: string };
    this.dataService.requestOffList
      .subscribe((data: { value: OptionOnLeave; label: string }[]) => {
        name = data.find(d => d.value == option)!;
      });
    return name.label;
  }

  handleSubmit() {
    (this.requestOnLeaveForm.controls['onLeave'] as FormArray).clear();
    if ((<HTMLInputElement>document.getElementById('reason')).value == '') {
      this.notification.warning('You must input reason!!!', '');
    } else {
      this.requestList.forEach((item) => {
        const onleaveItemForm = this.fb.group({
          dateLeave: new Date((item.date as Date).setHours(7)),
          option: item.option,
          reason: (<HTMLInputElement>document.getElementById('reason')).value,
        });
        (this.requestOnLeaveForm.controls['onLeave'] as FormArray).push(onleaveItemForm);
      });
      this.onleaveService.requestOnLeave(this.requestOnLeaveForm.value)
        .subscribe((response) => {
          this.onleaveService.getAllOnLeave(this.requestOnLeaveForm.value.employeeId);
          this.notification.success('Successfully!!!', `There are ${response.data.onLeave.length} items have been added!`);
        });;
      this.submit.emit();
    }
  }
}