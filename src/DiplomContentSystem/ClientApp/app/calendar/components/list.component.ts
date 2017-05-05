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

    getList = () => {
        return Promise.resolve([
                {
                    name:"Анализ предметной области",
                    startDate: new Date(2016,1,1),
                    endDate: new Date(2016,1,30),
                    checked:true
                },
                {
                    name:"Проектирование информационной системы",
                    startDate: new Date(2016,2,1),
                    endDate: new Date(2016,2,28),
                    checked:true
                },
                {
                    name:"Проектирование информационной базы данных системы",
                    startDate: new Date(2016,3,1),
                    endDate: new Date(2016,4,30),checked:true
                },
                {
                    name:"Физическая реализация системы",
                    startDate: new Date(2016,5,1),
                    endDate: new Date(2016,7,30)
                },
                {
                    name:"Оформление пояснительной записки",
                    startDate: new Date(2016,8,1),
                    endDate: new Date(2016,8,30)
                },
                {
                    name:"Нормоконтроль",
                    startDate: new Date(2016,9,1),
                    endDate: new Date(2016,9,4)
                },
                {
                    name:"Антиплагиат",
                    startDate: new Date(2016,9,5),
                    endDate: new Date(2016,9,14)
                },
                {
                    name:"Предзащита",
                    startDate: new Date(2016,9,15),
                    endDate: new Date(2016,9,15)
                },
                {
                    name:"Защита дипломной работы",
                    startDate: new Date(2016,10,7)
                }
            ]);
       // return this.service.getList(request).do((response) => { if (response.totalCount > 0) this.isLoading = false });
    }

    onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}

