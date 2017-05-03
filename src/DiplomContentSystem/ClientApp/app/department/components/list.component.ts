import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { RtList, filter } from 'right-angled';
import { Department } from '../models/department';
import { DepartmentService } from '../department.service';
import { SelectListItem } from '../../shared/select-list-item';
import { TeacherService } from '../../teacher/teacher.service';
@Component({
    selector: 'department-list',
    templateUrl: './list.component.html'
})
export class DepartmentsComponent {

    @filter()
    private name: string;

    @filter()
    private department: number = 0;

    private showFilter: boolean;
    private isLoading: boolean = true;

    private departmentOptions: SelectListItem[];

    constructor(private service: DepartmentService, private teacherService: TeacherService) {
        this.teacherService.getDepartments().subscribe(r => this.departmentOptions = r);
    }

    getDepartments = (request) => {
        this.isLoading = true;
        return this.service.getList(request).do((response) => { if (response.totalCount > 0) this.isLoading = false });
    }

    onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}

