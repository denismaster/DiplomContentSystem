import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { TemplateService } from '../templates.service';
import { Template } from '../models/template';
import {RtList,filter } from 'right-angled';
@Component({
    selector: 'templates',
    templateUrl: './list.component.html'
})
export class TemplatesComponent {

    @filter()
    private FIO:string;

    private showFilter:boolean;
    private isLoading: boolean = true;
    
    constructor(private service: TemplateService) {
    }

    getItems = (request)=>
    {
        this.isLoading = true;
        return this.service.getList(request).do((response)=>this.isLoading=false);
    }

     onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}

