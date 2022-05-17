import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { ApiDataService } from '../api-data.service';
import { faCheck, faXmark, faTrash, faPen } from '@fortawesome/free-solid-svg-icons';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  isVisible = false;
  projectDataForm!: FormGroup;
  status: boolean = false;
  showTable: boolean = false;
  apiData: any;
  isActiveIcon = faCheck;
  isNotActiveIcon = faXmark;
  deleteIcon = faTrash;
  editIcon = faPen

  getAPIData() {
    this.apiService.getDataFromAPI(this.status).subscribe((response: any) => {
      console.log(response)
      if (response.ResponseStatus == 1) {
        this.showTable = true;
        this.apiData = response.Result;
      } else {
        this.showTable = false;
        this.notification.create(
          'error',
          'Error!',
          'Something went wrong. Please try again later!'
        )
      }
    })
  }

  storeProjectData() {
    this.apiService.addProjectData(this.setProjectDataObject()).subscribe(
      (response: any) => { console.log(response) }
    )
  }

  showModal(): void {
    this.isVisible = true;
  }

  handleOk(): void {
    if (this.projectDataForm.valid) {
      this.apiService.addProjectData(this.setProjectDataObject()).subscribe(
        (response: any) => { 
          console.log(response)
          if(response.ResponseStatus == 1){
            this.notification.create(
              'success',
              'Success',
              'Project added successfully!'
            )
            this.handleCancel();
          } else {
            this.notification.create(
              'error',
              'Error',
              'Something went wrong. Please try again later!'
            )
            this.handleCancel();
          }
        }
      )
    } else {
      Object.values(this.projectDataForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  handleCancel(): void {
    this.projectDataForm.reset();
    this.isVisible = false;
  }

  setProjectDataObject() {
    var body = {
      ProjectName: this.projectDataForm.controls['projectName'].value,
      ProjectDescription: this.projectDataForm.controls['projectDescription'].value,
      StartDate: this.projectDataForm.controls['startDate'].value,
      ProjectStatus: this.projectDataForm.controls['projectStatus'].value,
      IsDelete: this.projectDataForm.controls['isDelete'].value,
      IsActive: this.projectDataForm.controls['isActive'].value
    }

    return body;
  }

  logout() {
    localStorage.removeItem('accessToken');
    this.router.navigate(['/login']);
  }

  editProject(projectId: number){
    alert(projectId);
  }

  deleteProject(projectId: number){
    this.apiService.deleteProject(projectId).subscribe((response: any) => { 
      console.log(response)
      if(response.ResponseStatus == 1){
        this.notification.create(
          'success',
          'Success',
          'Project deleted successfully!'
        )
        this.apiData = this.apiData.filter((d: any) => d.ProjectId !== projectId);
      } else if (response.ResponseStatus == 2){
        this.notification.create(
          'warning',
          'Warning',
          `${response.Message}`
        )
      }
      else {
        this.notification.create(
          'error',
          'Error',
          'Something went wrong. Please try again later!'
        )
      }
    })
  }

  constructor(private router: Router, private apiService: ApiDataService, private notification: NzNotificationService, private fb: FormBuilder) {
    this.projectDataForm = this.fb.group({
      projectName: [null, [Validators.required]],
      projectDescription: [null, [Validators.required]],
      startDate: [null, [Validators.required]],
      projectStatus: [null, [Validators.required]],
      isDelete: [false],
      isActive: [false],
    })
  }

  ngOnInit(): void {
    if (!localStorage.getItem('accessToken')) {
      this.router.navigate(['/login']);
    }
  }

}
