import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { RtList, filter } from 'right-angled';
import { CalendarEvent } from '../models/calendar';
import { CalendarService } from '../calendar.service';
import { SelectListItem } from '../../shared/select-list-item';
import { TeacherService } from '../../teacher/teacher.service';
@Component({
    selector: 'calendar-list',
    templateUrl: './list.component.html'
})
export class CalendarsComponent {

    @filter()
    private name: string;

    @filter()
    private department: number = 0;

    private showFilter: boolean;
    private isLoading: boolean = true;

    private departmentOptions: SelectListItem[];

    constructor(private service: CalendarService, private teacherService: TeacherService) {
       // this.teacherService.getDepartments().subscribe(r => this.departmentOptions = r);
    }

    getList = (request) => {
       return this.service.getStages();
    }

    onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }

    download()
    {
        
    }
}

