import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NotificationService } from 'src/app/services/notification.service';
import { Notification } from 'src/app/interfaces/interfaceReponse';
import Quill from 'quill';
import { ImageHandler } from 'ngx-quill-upload';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DataService } from 'src/app/services/data.service';
import { Level } from 'src/app/enums/Enum';
import { SalaryService } from 'src/app/services/salary.service';
Quill.register('modules/imageHandler', ImageHandler);

@Component({
  selector: 'app-notification-detail',
  templateUrl: './notification-detail.component.html',
  styleUrls: ['./notification-detail.component.css']
})
export class NotificationDetailComponent implements OnInit {
  notification!: Notification;
  form!: FormGroup;
  level = Level;

  constructor(
    private notificationService: NotificationService,
    private salaryService: SalaryService,
    private dataService: DataService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.notificationService.readNotification(params['id'])
        .subscribe((response) => {
          this.notification = response.data[0];
          this.form = this.fb.group({ content: [null] });
          this.form.patchValue(this.notification);
        });
    });
  }

  getPositionName(id: number) {
    return this.dataService.positionList.value.find(i => i.id == id)?.name;
  }

  confirmSalary(id: string, action: number){
    this.salaryService.confirmSalary(id, action)
      .subscribe((response) => {

      })
  }
}