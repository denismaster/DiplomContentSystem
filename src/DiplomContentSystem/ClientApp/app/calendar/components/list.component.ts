import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';
import { RtList, filter } from 'right-angled';
import { CalendarEvent } from '../models/calendar';
import { CalendarService } from '../calendar.service';
import { SelectListItem } from '../../shared/select-list-item';
import { TeacherService } from '../../teacher/teacher.service';
import * as FileSaver from "file-saver";
import { Router, ActivatedRoute } from '@angular/router';
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
    private id: number;
    private departmentOptions: SelectListItem[];

    private selectedId: number = undefined;

    constructor(private service: CalendarService,private router: Router, private activatedRoute:ActivatedRoute) {
       // this.teacherService.getDepartments().subscribe(r => this.departmentOptions = r);
       this.id = activatedRoute.snapshot.params['id'];
       if(!this.id){
            router.navigateByUrl("['/404']");
        }
    }

    getList = (request) => {
       return this.service.getStages(this.id);
    }

    onListInit(list: RtList): void {
        list.registerFilterTarget(this);
    }

    download()
    {
        this.service.getCalendarFile(this.id).subscribe((response:Response)=>{
            let blob = new Blob([response.blob()], {type: "application/vnd.openxmlformats-officedocument.wordprocessingml.document"});
            FileSaver.saveAs(blob, "calendar.docx");
        })
    }
}

