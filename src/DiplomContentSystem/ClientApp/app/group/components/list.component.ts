import { Component } from '@angular/core';
import { Http } from '@angular/http';
import {RtList,filter } from 'right-angled';
import { Group } from '../models/group';
import { GroupService } from '../group.service';
@Component({
    selector: 'group-list',
    templateUrl: './list.component.html'
})
export class GroupsComponent {

    @filter()
    private FIO:string;

    private showFilter:boolean;
    private isLoading: boolean = true;
    
    constructor(private service: GroupService) {
    }

    getGroups = (request)=>
    {
        this.isLoading = true;
        return this.service.getList(request).do((response)=>this.isLoading=false);
    }

     onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}

