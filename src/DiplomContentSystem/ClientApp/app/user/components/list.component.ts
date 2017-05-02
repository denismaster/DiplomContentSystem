import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { UserService } from '../user.service';
import { User } from '../models/user';
import {RtList,filter } from 'right-angled';
@Component({
    selector: 'users',
    templateUrl: './list.component.html'
})
export class UsersComponent {

    @filter()
    private FIO:string;

    private showFilter:boolean;
    private isLoading: boolean = true;
    
    constructor(private service: UserService) {
    }

    getUsers = (request)=>
    {
        this.isLoading = true;
        return this.service.getList(request).do((response)=>this.isLoading=false);
    }

     onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}

