import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { TeacherService } from '../teacher.service';
import { Teacher } from '../models/teacher';
import {RtList,filter } from 'right-angled';
@Component({
    selector: 'teachers',
    templateUrl: './teacher.component.html'
})
export class TeachersComponent {

    @filter()
    private FIO:string;

    private showFilter:boolean;
    private isLoading: boolean = true;
    
    constructor(private service: TeacherService) {
    }

    getTeachers = (request)=>
    {
        this.isLoading = true;
        return this.service.getList(request).do((response)=>this.isLoading=false);
    }

     onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}

