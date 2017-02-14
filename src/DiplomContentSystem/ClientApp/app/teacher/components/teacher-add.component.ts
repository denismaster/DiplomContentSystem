import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { TeacherService } from '../teacher.service';
import { Teacher } from '../models/teacher';
import { CustomValidators } from '../../shared/custom-validators';

@Component({
    selector: 'teachers-add',
    templateUrl: './teacher-add.component.html'
})
export class TeachersAddComponent {
    private form: FormGroup;
    constructor(private service: TeacherService, private router: Router, private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            "firstName": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
            "lastName": [null, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
            "middleName": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
            "maxWorkCount": [undefined, Validators.compose([Validators.required,CustomValidators.minValue(1)])],
            "position": [undefined]
        });
    }

    private submit(value: any): void {
        event.preventDefault();

        const teacher = new Teacher();
        teacher.fio = [value.lastName, value.firstName, value.middleName].join(" ");
        teacher.position = value.position;
        teacher.maxWorkCount = value.maxWorkCount;
        
        this.service.add(teacher).subscribe(result=>this.goBack());
    }

    public goBack(): void {
        this.router.navigate(['/teachers']);
    }
}
