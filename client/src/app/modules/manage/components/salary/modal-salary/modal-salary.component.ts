import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { Observable } from 'rxjs';
import { Position } from 'src/app/interfaces/interfaceReponse';
import { Level } from 'src/app/enums/Enum';
import { DataService } from 'src/app/services/data.service';
import { SalaryService } from 'src/app/services/salary.service';
import { PositionService } from 'src/app/services/position.service';
import { NzModalService } from 'ng-zorro-antd/modal';

@Component({
  selector: 'app-modal-salary',
  templateUrl: './modal-salary.component.html',
  styleUrls: ['./modal-salary.component.css']
})
export class ModalSalaryComponent implements OnInit {
  @Input() isVisibleModal: boolean = false;
  @Output() cancel: EventEmitter<boolean> = new EventEmitter();
  salaryForm!: FormGroup;
  levelList = new Observable<{ value: Level; label: string }[]>();
  positionList = new Observable<Position[]>();

  constructor(
    private salaryService: SalaryService,
    private dataService: DataService,
    private positionService: PositionService,
    private fb: FormBuilder,
    private notification: NzNotificationService,
    private modal: NzModalService
    ) { }

  ngOnInit(): void {
    this.positionService.getAllPosition();
    this.levelList = this.dataService.levelList;
    this.positionList = this.positionService.positionList$;
    this.salaryForm = this.fb.group({
      level: [null, Validators.required],
      positionId: [null, Validators.required],
      money: [100000, Validators.required],
      welfare: [100000, Validators.required],
      synchronized: [false],
    });
  }

  submitForm() {
    if (this.salaryForm.valid) {
      this.salaryService
        .createSalary(this.salaryForm.value)
        .subscribe((response) => {
          if (response.statusCode == 200) {
            this.salaryService.salaryList$.next([response.data,...this.salaryService.salaryList$.value]);
            this.notification.success('Successfully!!!', '');
            this.cancel.emit();
          }
        });
    } else {
      Object.values(this.salaryForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  handleCancel() {
    this.cancel.emit();
  }

  confirmSyn() {
    this.modal.confirm({
      nzTitle: 'This job is currently being published. Are you sure you want to fix it?',
      nzOnOk: () => { this.salaryForm.controls['synchronized'].setValue(true); this.submitForm()},
      nzOnCancel: () => {this.submitForm()}
    });
  }
}
