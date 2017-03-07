import { Component } from '@angular/core';
import { Http } from '@angular/http';
import {RtList,filter } from 'right-angled';
import { StudentService } from '../student.service';
@Component({
    selector: 'student-list',
    templateUrl: './student.component.html'
})
export class StudentComponent {

    @filter()
    private FIO:string;

    private showFilter:boolean;
    private isLoading: boolean = true;
    
    constructor(private service: StudentService) {
    }

    getStudents = (request)=>
    {
        this.isLoading = true;
        const observable = this.service.getList(request);
        observable.subscribe(a=>this.isLoading=false);
        return observable;
    }

     onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}

