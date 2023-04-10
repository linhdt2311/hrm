import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LoginResponse, TimeKeepingResponse, TimeWorkingResponse } from 'src/app/interfaces/interfaceReponse';
import { ManageService } from '../../../services/manage.service';

@Component({
  selector: 'app-modal-list-checkin',
  templateUrl: './modal-list-checkin.component.html',
  styleUrls: ['./modal-list-checkin.component.css']
})
export class ModalListCheckinComponent implements OnInit {
  @Input() visibleModal = false;
  @Output() cancel = new EventEmitter();
  myTimeKeepingList: TimeKeepingResponse[] = [];
  myTimeWorking!: TimeWorkingResponse;
  monthList: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
  yearList: number[] = [];
  today = new Date();
  user!: LoginResponse;
  totalPunish: number = 0;
  month = new Date().getMonth() + 1;
  year =  new Date().getFullYear();

  constructor(
    private manageService: ManageService,
  ) { }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('user') || sessionStorage.getItem('user') || '{}');
    for (let i = -10; i <= 10; i++) {
      this.yearList = [...this.yearList, this.today.getFullYear() + i];
    };
    this.manageService.myTimeKeepingList$.subscribe((data) => {
      this.myTimeKeepingList = data;
      this.totalPunish = data.filter(i => i.punish == true).length;
    });
    this.manageService.timeWorkingList$.subscribe((data) => {
      this.myTimeWorking = data.find(i => i.employeeId = this.user.id)!;
    })
  }

  filterYear(year: number) {
    this.manageService.getTimeKeepingForUser(this.user.id, this.month, year);
    this.yearList = [];
    for (let i = -10; i <= 10; i++) {
      this.yearList = [...this.yearList, year + i];
    };
  }

  filterMonth(month: number) {
    this.manageService.getTimeKeepingForUser(this.user.id, month, this.year);
  }

  handleCancel() {
    this.cancel.emit();
  }
}
