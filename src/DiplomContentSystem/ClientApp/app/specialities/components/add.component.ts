import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { SpecialityService } from '../speciality.service';
import { Speciality } from '../models/speciality';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';

@Component({
    selector: 'groups-add',
    templateUrl: './add.component.html'
})
export class SpecialityAddComponent implements OnInit {
    private form: FormGroup;
    private specialityOptions:SelectListItem[];
    private errors: string[] = [];

    constructor(private service: SpecialityService, private router: Router, private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            "name": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
            "shortName": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
            "code": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
            "department": ["", Validators.required],
        });
    }
    
    ngOnInit()
    {
        this.service.getSpecialities().subscribe(r=>this.specialityOptions = r);
    }

    private submit(value: any): void {
        event.preventDefault();

        const speciality = new Speciality();
        speciality.name = value.name;
        speciality.departmentId = value.speciality;
        
        this.service.add( speciality).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/specialities']);
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
