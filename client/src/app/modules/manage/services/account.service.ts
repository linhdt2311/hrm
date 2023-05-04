import { Injectable } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { BehaviorSubject, catchError, of } from 'rxjs';
import { TimeWorkingResponse } from 'src/app/interfaces/interfaceReponse';
import { ChangePassword, Employee } from 'src/app/interfaces/interfaces';
import { ApiService } from 'src/app/services/api.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  public requestTimeWorkingList$ = new BehaviorSubject<TimeWorkingResponse[]>([]);
  public isSuccess: boolean = false;

  constructor(
    private apiService: ApiService,
  ) { 
    const user = JSON.parse(localStorage.getItem('user') || sessionStorage.getItem('user') || '{}');
    this.getAllRequestChangeTimeWorkingForUser(user.id);
  }

  getAllRequestChangeTimeWorkingForUser(id: string) {
    this.apiService
      .getAllRequestChangeTimeWorkingForUser(id)
      .subscribe((response) => {
        this.requestTimeWorkingList$.next(response.data);
      });
  }
}
