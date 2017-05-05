import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { CalendarService } from '../calendar.service';
import { CalendarEvent } from '../models/calendar';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';

@Component({
    selector: 'groups-add',
    templateUrl: './add.component.html'
})
export class CalendarAddComponent implements OnInit {
    private form: FormGroup;
    private specialityOptions:SelectListItem[];
    private errors: string[] = [];

    constructor(private service: CalendarService, private router: Router, private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            "name": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
            "speciality": ["", Validators.required],
        });
    }
    
    ngOnInit()
    {
        this.service.getSpecialities().subscribe(r=>this.specialityOptions = r);
    }

    private submit(value: any): void {
        event.preventDefault();

        const calendar= new CalendarEvent();
        calendar.name = value.name;
       calendar.specialityId = value.speciality;
        
        this.service.add(calendar).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/calendars']);
    }

    public checkResult(result:OperationResult):void{
        if(!result.hasErrors)
        {
            this.goBack();
        }
        else
        {
            this.errors = result.errors;
        }
    }
}
