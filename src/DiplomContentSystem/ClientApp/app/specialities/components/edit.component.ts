import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Speciality } from '../models/speciality';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';
import { SpecialityService } from '../speciality.service';

@Component({
    selector: 'group-edit',
    templateUrl: './edit.component.html'
})
export class SpecialityEditComponent implements OnInit {
    private form: FormGroup;
    private errors: string[] = [];

    private specialityOptions: SelectListItem[];
    private id: number;
    private group: Speciality;
    private isLoading: boolean = true;

    constructor(private service: SpecialityService, private router: Router, private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder) {
        this.id = activatedRoute.snapshot.params['id'];
        if (!this.id) {
            router.navigateByUrl("['/404']");
        }
        this.service.getOne(this.id)
            .subscribe(result => {
                this.isLoading = false;
                this.form = this.formBuilder.group({
                    "name": [result.name, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
                    "shortName": [result.name, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
                    "code": [result.name, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
                    "department": [result.departmentId, Validators.required],
                });
            })
    }

    ngOnInit() {
        this.form = this.formBuilder.group({
            "name": [undefined],
            "speciality": [undefined],
        });
        this.service.getSpecialities().subscribe(r => this.specialityOptions = r);
    }

    private submit(value: any): void {
        event.preventDefault();

        const speciality = new Speciality();
        speciality.id = this.id;
        speciality.name = value.name;
        speciality.departmentId = value.department;

        this.service.update(speciality).subscribe(result => this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/specialities']);
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
