import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { TeacherService } from '../teacher.service';
import { Teacher } from '../models/teacher';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';

@Component({
    selector: 'teachers-add',
    templateUrl: './teacher-add.component.html'
})
export class TeachersAddComponent implements OnInit {
    private form: FormGroup;
    private positionOptions:SelectListItem[];
    private specialityOptions:SelectListItem[];
    private errors: string[] = [];

    constructor(private service: TeacherService, private router: Router, private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            "fio": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty(), CustomValidators.wordCount(3)])],
            "maxWorkCount": [undefined, Validators.compose([Validators.required,CustomValidators.minValue(1)])],
            "position": ["", Validators.required],
            "speciality": ["", Validators.required]
        });
    }
    
    ngOnInit()
    {
        this.service.getPositions().subscribe(r=>this.positionOptions = r);
        this.service.getSpecialities().subscribe(r=>this.specialityOptions = r);
    }

    private submit(value: any): void {
        event.preventDefault();

        const teacher = new Teacher();
        teacher.fio = value.fio;
        teacher.positionId = value.position;
        teacher.maxWorkCount = value.maxWorkCount;
        teacher.departmentId = value.speciality;
        
        this.service.add(teacher).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/teachers']);
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
