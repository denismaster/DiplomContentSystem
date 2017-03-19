import { Component } from '@angular/core';
import { Http } from '@angular/http';
import {RtList,filter } from 'right-angled';
import { DiplomWorksService } from '../diplom-works.service';
@Component({
    selector: 'diploms-list',
    templateUrl: './list.component.html'
})
export class DiplomWorksListComponent {

    @filter()
    private FIO:string;

    private showFilter:boolean;
    private isLoading: boolean = true;
    
    constructor(private service: DiplomWorksService) {
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

