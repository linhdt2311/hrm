import { Component, OnInit } from '@angular/core';
import { Evaluate } from 'src/app/interfaces/interfaceReponse';
import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Employee } from 'src/app/interfaces/interfaces';
import { Level } from 'src/app/enums/Enum';
import { Observable } from 'rxjs';
import { EvaluateService } from 'src/app/services/evaluate.service';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-evaluate',
  templateUrl: './evaluate.component.html',
  styleUrls: ['./evaluate.component.css']
})
export class EvaluateComponent implements OnInit {
  evaluateList: Evaluate[] = [];
  level = Level;
  visibleModal: boolean = false;
  data!: Evaluate;
  employeeList = new Observable<Employee[]>();
  monthList: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
  yearList: number[] = [];
  filterEvaluateName!: string | null;
  filterEvaluateMonth!: number | null;
  filterEvaluateYear!: number | null;

  constructor(
    private evaluateService: EvaluateService,
    private employeeService: EmployeeService,
  ) { }

  ngOnInit(): void {
    this.employeeService.getAllEmployee();
    this.employeeList = this.employeeService.employeeList$;
    this.evaluateService.getAllEvaluate();
    this.evaluateService.evaluateList$.subscribe((data) => {
      this.evaluateList = data;
    });
    for (let i = -10; i <= 10; i++) {
      this.yearList = [...this.yearList, new Date().getFullYear() + i];
    };
  }

  drop(event: CdkDragDrop<string[], string[], any>): void {
    const item = this.evaluateList[event.previousIndex];
    this.evaluateList.splice(event.previousIndex, 1);
    this.evaluateList.splice(event.currentIndex, 0, item);
    this.evaluateList = [...this.evaluateList];
  }

  getUserName(id: string) {
    let name: string | undefined;
    this.employeeService.employeeList$
      .subscribe((data: Employee[]) => {
        name = data.find(d => d.id == id)?.fullName;
      });
    return name;
  }

  openModal(data: Evaluate) {
    this.data = data;
    this.visibleModal = true;
  }

  filterEvaluate() {
    this.evaluateService.evaluateList$.subscribe((data) => { this.evaluateList = data });
    if (this.filterEvaluateName != null) {
      this.evaluateList = this.evaluateList.filter(i => i.employeeId == this.filterEvaluateName);
    }
    if (this.filterEvaluateMonth != null) {
      this.evaluateList = this.evaluateList.filter(i => new Date(i.dateEvaluate).getMonth() == this.filterEvaluateMonth);
    }
    if (this.filterEvaluateYear != null) {
      this.evaluateList = this.evaluateList.filter(i =>
        new Date(new Date(i.dateEvaluate).getDate() + '/' + new Date(i.dateEvaluate).getMonth() + '/' + new Date(i.dateEvaluate).getFullYear()).getFullYear() == this.filterEvaluateYear);
      this.yearList = [];
      for (let i = -10; i <= 10; i++) {
        this.yearList = [...this.yearList, this.filterEvaluateYear + i];
      };
    }
  }

  searchName(id: string) {
    this.filterEvaluateName = id;
    this.filterEvaluate();
  }

  searchMonth(month: number) {
    this.filterEvaluateMonth = month;
    this.filterEvaluate();
  }

  searchYear(year: number) {
    this.filterEvaluateYear = year;
    this.filterEvaluate();
  }
}