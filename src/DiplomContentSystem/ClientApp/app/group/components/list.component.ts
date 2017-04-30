import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { RtList, filter } from 'right-angled';
import { Group } from '../models/group';
import { GroupService } from '../group.service';
import { SelectListItem } from '../../shared/select-list-item';
import { TeacherService } from '../../teacher/teacher.service';
@Component({
    selector: 'group-list',
    templateUrl: './list.component.html'
})
export class GroupsComponent {

    @filter()
    private name: string;

    @filter()
    private department: number = 0;

    private showFilter: boolean;
    private isLoading: boolean = true;

    private departmentOptions: SelectListItem[];

    constructor(private service: GroupService, private teacherService: TeacherService) {
        this.teacherService.getDepartments().subscribe(r => this.departmentOptions = r);
    }

    getGroups = (request) => {
        this.isLoading = true;
        return this.service.getList(request).do((response) => { if (response.totalCount > 0) this.isLoading = false });
    }

    onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}

