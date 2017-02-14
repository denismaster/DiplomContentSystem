import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { TeacherService } from '../teacher.service';
import { Teacher } from '../models/teacher';
import {RtList } from 'right-angled';
@Component({
    selector: 'teachers',
    templateUrl: './teacher.component.html'
})
export class TeachersComponent {

    constructor(private service: TeacherService) {
    }

    getTeachers = (request)=>
    {
        return this.service.getList(request);
    }

     onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}

