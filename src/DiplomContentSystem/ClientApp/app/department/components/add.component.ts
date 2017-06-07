import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { DepartmentService } from '../department.service';
import { Department } from '../models/department';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';

@Component({
    selector: 'departments-add',
    templateUrl: './add.component.html'
})
export class DepartmentAddComponent {
    private form: FormGroup;
    private errors: string[] = [];

    constructor(private service: DepartmentService, private router: Router, private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            "name": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
            "shortName": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
        });
    }

    private submit(value: any): void {
        event.preventDefault();

        const department = new Department();
        department.name = value.name;
         department.shortName = value.shortName;

        this.service.add(department).subscribe(result => this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/departments']);
    }

    public checkResult(result: OperationResult): void {
        if (!result.hasErrors) {
            this.goBack();
        }
        else {
            this.errors = result.errors;
        }
    }
}
