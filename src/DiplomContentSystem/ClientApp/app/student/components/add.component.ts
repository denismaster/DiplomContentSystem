import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { StudentService } from '../student.service';
import { Student } from '../models/student';

@Component({
    selector: 'student-add',
    templateUrl: './add.component.html'
})
export class StudentAddComponent {
    private form: FormGroup;
    private errors: string[] = [];

    constructor(private service: StudentService, private router: Router, private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            "fio": [undefined, [Validators.required, CustomValidators.notEmpty(), CustomValidators.wordCount(3)]],
            "group": [undefined, Validators.required],
            "speciality": [undefined, Validators.required]
        });
    }

    private submit(value: any): void {
        event.preventDefault();

        const student = new Student();
        student.fio = value.fio;
        
        this.service.add(student).subscribe(result=>this.checkResult(result));
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