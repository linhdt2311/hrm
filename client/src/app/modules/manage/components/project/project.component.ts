import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProjectResponse } from 'src/app/interfaces/interfaceReponse';
import { EmployeeService } from 'src/app/services/employee.service';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {
  visibleCreateOrEditProject: boolean = false;
  projectList = new Observable<ProjectResponse[] | any>();

  constructor(
    private projectService: ProjectService,
    private employeeService: EmployeeService,
  ) { }

  ngOnInit(): void {
    this.projectService.getAllProject();
    this.projectList = this.projectService.projectList$;
  }

  openModal() {
    this.employeeService.getAllEmployee();
    this.visibleCreateOrEditProject = true;
  }

  closeModal() {
    this.visibleCreateOrEditProject = false;
  }

  editProject(projectId: string) {
    this.projectService.getOnlyProject(projectId);
    this.visibleCreateOrEditProject = true;
  }
}
