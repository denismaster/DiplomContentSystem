import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { RtList, filter } from 'right-angled';
import { Speciality } from '../models/speciality';
import { SpecialityService } from '../speciality.service';
import { SelectListItem } from '../../shared/select-list-item';
import { TeacherService } from '../../teacher/teacher.service';
@Component({
    selector: 'speciality-list',
    templateUrl: './list.component.html'
})
export class SpecialitiesComponent {

    @filter()
    private name: string;

    @filter()
    private department: number = 0;

    private showFilter: boolean;
    private isLoading: boolean = true;

    private departmentOptions: SelectListItem[];

    constructor(private service: SpecialityService, private teacherService: TeacherService) {
        this.teacherService.getDepartments().subscribe(r => {this.departmentOptions = r});
    }

    getSpecialities = (request) => {
        this.isLoading = true;
        return this.service.getList(request).do((response) => { console.log(response); if (response.totalCount > 0) this.isLoading = false });
    }

    onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}

