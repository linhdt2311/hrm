import { Injectable } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { BehaviorSubject, catchError, of } from 'rxjs';
import { Level, Position } from 'src/app/enums/Enum';
import { Employee } from 'src/app/interfaces/interfaces';
import { ApiService } from 'src/app/services/api.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  public employeeList$ = new BehaviorSubject<Employee[]>([]);

  constructor(
    private apiService: ApiService,
    private notification: NzNotificationService,
    private message: NzMessageService,
  ) { 
    this.getAllEmployee();
  }

  getAllEmployee() {
    this.apiService
      .getAllEmployee()
      .pipe(catchError((err) => {
        this.message.error('Server not responding!!!', { nzDuration: 3000 });
        return of(err);
      }))
      .subscribe((response) => {
        this.employeeList$.next(response);
      });
  }

  saveEmployee(payload: Employee) {
    this.apiService
      .saveEmployee(payload)
      .pipe(catchError((err) => {
        this.notification.error('Error!!!', 'An error occurred during execution!');
        return of(err);
      }))
      .subscribe((response) => {
        if (response.id) {
          this.notification.success('Successfully!', `Create ${Level[response.level]} ${Position[response.position]} ${response.fullName}`);
          if (payload.id) {
            this.employeeList$.value.splice(this.employeeList$.value.findIndex((item) => item.id === response.id), 1, response);
            this.employeeList$.next([...this.employeeList$.value]);
          } else {
            this.employeeList$.next([response, ...this.employeeList$.value]);
          };
        };
      });
  }

  deleteEmployee(id: string) {
    this.apiService
      .deleteEmployee(id)
      .subscribe(() => {
        const index = this.employeeList$.value.findIndex((item) => item.id == id);
        this.employeeList$.value.splice(index, 1);
        this.employeeList$.next([...this.employeeList$.value]);
      });
  }
}