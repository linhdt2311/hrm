import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NzModalRef, NzModalService } from 'ng-zorro-antd/modal';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { Observable } from 'rxjs';
import { OptionOnLeave, Status } from 'src/app/enums/Enum';
import { ManageService } from '../../services/manage.service';

@Component({
  selector: 'app-request-off',
  templateUrl: './request-off.component.html',
  styleUrls: ['./request-off.component.css']
})
export class RequestOffComponent implements OnInit {
  date = new Date();
  requestList: { date: Date, option: OptionOnLeave, status: Status }[] = [];
  onLeaveList = new Observable<any[]>();
  isVisibleModal: boolean = false;
  status = Status;
  confirmModal?: NzModalRef;

  constructor(
    private manageService: ManageService,
    private datepipe: DatePipe,
    private notification: NzNotificationService,
    private modal: NzModalService,
    ) { }

  ngOnInit(): void {
    this.requestList = [];
    this.onLeaveList = this.manageService.requestOffList;
  }

  selectDateRequest(requestDate: Date) {
    let date = this.datepipe.transform(requestDate, 'MM/dd/yyyy')?.toString()!;
    let index = this.requestList.findIndex((item) => this.datepipe.transform(item.date, 'MM/dd/yyyy') == date);
    if (requestDate.getTime() >= this.date.getTime()) {
      if (index != -1) {
        this.requestList.splice(index, 1);
        this.requestList = [...this.requestList];
      } else {
        let newRequest = { date: new Date(date), option: OptionOnLeave.OffMorning, status: Status.New };
        this.requestList = [...this.requestList, newRequest];
      }
    } else {
      this.notification.error('You cannot request in past!!!', '');
    }
  }

  changeOptionOnLeave(date: Date, option: OptionOnLeave, status: Status) {
    let data = { date: new Date(date), option: option, status: status };
    this.requestList.splice(this.requestList.findIndex((item) =>
      this.datepipe.transform(item.date, 'dd/MM/YYYY') === this.datepipe.transform(data.date, 'dd/MM/YYYY')
    ), 1, data);
    this.requestList = [...this.requestList];
  }

  openModal() {
    this.isVisibleModal = true;
  }

  formatDate(date: Date) {
    return this.datepipe.transform(date, 'MM/dd/YYYY');
  }

  handleDelete() {
    this.confirmModal = this.modal.confirm({
      nzTitle: `Delete request in ?`,
      nzContent: '',
      nzOnOk: () =>
        new Promise((resolve, reject) => {
          setTimeout(Math.random() > 0.5 ? resolve : reject, 1000);
        }).catch(() => console.log('Oops errors!'))
    });
  }
}
