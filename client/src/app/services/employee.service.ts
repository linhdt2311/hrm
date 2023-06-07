import { Injectable } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { BehaviorSubject, Observable, catchError, of } from 'rxjs';
import { Status } from 'src/app/enums/Enum';
import { Employee } from 'src/app/interfaces/interfaces';
import { ApiResponse } from '../interfaces/interfaceReponse';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { NzMessageService } from 'ng-zorro-antd/message';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  public employeeList$ = new BehaviorSubject<Employee[]>([]);
  public requestChangeInfoList$ = new BehaviorSubject<Employee[]>([]);

  constructor(
    private notification: NzNotificationService,
    private httpClient: HttpClient,
    private message: NzMessageService,
  ) { }

  getAllEmployee() {
    return this.httpClient.get<ApiResponse>(environment.baseUrl + 'employee/getAll')
      .pipe(catchError((err) => {
        this.message.error('Server not responding!!!', { nzDuration: 3000 });
        return of(err);
      }))
      .subscribe((response) => {
        this.employeeList$.next(response.data);
      });
  }

  saveEmployee(payload: Employee): Observable<ApiResponse> {
    return this.httpClient.post<ApiResponse>(environment.baseUrl + 'employee/save', payload)
      .pipe(catchError((err) => {
        this.notification.error('Error!!!', err.error.message);
        return of(err);
      }));
  }

  deleteEmployee(id: string): Observable<ApiResponse> {
    return this.httpClient.delete<ApiResponse>(environment.baseUrl + 'employee/delete?id=' + id)
      .pipe(catchError((err) => {
        this.notification.error('Error!!!', err.error.message);
        return of(err);
      }));
  }

  getAllRequestChangeInfo() {
    return this.httpClient.get<ApiResponse>(environment.baseUrl + 'employee/getAllRequestChangeInfo')
      .pipe(catchError((err) => {
        this.notification.error('Error!', err.error.message);
        return of(err);
      }))
      .subscribe((response) => {
        this.requestChangeInfoList$.next(response.data);
      });
  }

  updateStatusUserInfo(payload: { id: string, pmId: string, status: Status }): Observable<ApiResponse> {
    return this.httpClient.put<ApiResponse>(environment.baseUrl + 'employee/updateStatus', payload)
      .pipe(catchError((err) => {
        this.notification.error('Error!!!', err.error.message);
        return of(err);
      }));
  }
}
