import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { StageService } from '../stage.service';
import { Stage } from '../models/stage';
import { RtList, filter } from 'right-angled';

@Component({
    selector: 'stages',
    templateUrl: './stage.component.html'
})
export class StagesComponent {

    @filter()
    private FIO: string;

    private showFilter: boolean;
    private isLoading: boolean = true;

    constructor(private service: StageService) {
    }

    getStages = (request) => {
        return this.service.getList(request);
    }

    onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }
}



