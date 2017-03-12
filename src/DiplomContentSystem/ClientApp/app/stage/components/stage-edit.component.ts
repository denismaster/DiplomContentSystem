import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { StageService } from '../stage.service';
import { Stage } from '../models/stage';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';

@Component({
    selector: 'stages-edit',
    templateUrl: './stage-edit.component.html'
})
export class StagesEditComponent implements OnInit {
    private form: FormGroup;
    private errors: string[] = [];

    private id: number;
    private stage: Stage;
    private isLoading: boolean = true;

    constructor(private service: StageService, private router: Router, private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder) {
        this.id = activatedRoute.snapshot.params['id'];
        if (!this.id) {
            router.navigateByUrl("['/404']");
        }
        this.service.getOne(this.id)
            .subscribe(result => {
                this.isLoading = false;
                this.form = this.formBuilder.group({
                    "name": [result.name, Validators.compose([Validators.required, CustomValidators.notEmpty(), Validators.maxLength(50)])],
                    "description": [result.description, Validators.compose([Validators.required, CustomValidators.notEmpty(), Validators.maxLength(300)])],
                    "startDate": [result.startDate, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
                    "endDate": [result.endDate, Validators.compose([Validators.required, CustomValidators.notEmpty()])]
                });               
            })
    }

    ngOnInit() {
        this.form = this.formBuilder.group({
            "name": [undefined],
            "description": [undefined],
            "startDate": [undefined],
            "endDate": [undefined],
        });
    }

    private submit(value: any): void {
        event.preventDefault();

        const stage = new Stage();
        stage.id = this.id;
        stage.name = value.name;
        stage.description = value.description;
        stage.startDate = value.startDate;
        stage.endDate = value.endDate;

        this.service.update(stage).subscribe(result => this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/stages']);
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