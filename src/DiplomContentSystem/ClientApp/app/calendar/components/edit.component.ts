import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { CalendarEvent } from '../models/calendar';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';
import { CalendarService } from '../calendar.service';

@Component({
    selector: 'group-edit',
    templateUrl: './edit.component.html'
})
export class CalendarEditComponent implements OnInit {
    private form: FormGroup;
    private errors: string[] = [];

    private specialityOptions:SelectListItem[];
    private id:number;
    private calendar: CalendarEvent;
    private isLoading:boolean=true;

    constructor(private service: CalendarService, private router: Router, private activatedRoute:ActivatedRoute, private formBuilder: FormBuilder) {
        this.id = activatedRoute.snapshot.params['id'];
        if(!this.id){
            router.navigateByUrl("['/404']");
        }
        this.service.getOne(this.id)
            .subscribe(result=>{
                this.isLoading=false;
                this.form = this.formBuilder.group({
                    "name": [result.name, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
                    "speciality": [result.specialityId, Validators.required],
                });        
            })
    }

    ngOnInit()
    {
        this.form = this.formBuilder.group({
                    "name": [undefined],
                    "speciality": [undefined],
                });   
        this.service.getSpecialities().subscribe(r=>this.specialityOptions = r);
    }

    private submit(value: any): void {
        event.preventDefault();

        const calendar = new CalendarEvent();
        calendar.id = this.id;
        calendar.name = value.name;
        calendar.specialityId = value.speciality;
        
        this.service.update(calendar).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/calendar']);
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
