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
    private loading: boolean = true;
    constructor(private service: TeacherService) {
    }

    getTeachers = (request)=>
    {
        this.loading = true;
        const observable = this.service.getList(request);
        observable.subscribe(a=>this.loading=false);
        return observable;
    }

     onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}

