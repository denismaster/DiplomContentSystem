import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { StageService } from '../stage.service';
import { Stage } from '../models/stage';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';

@Component({
    selector: 'stages-add',
    templateUrl: './stage-add.component.html'
})
export class StagesAddComponent {
    private form: FormGroup;
    private errors: string[] = [];

    constructor(private service: StageService, private router: Router, private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            "name": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty(), Validators.maxLength(50)])],
            "description": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty(), Validators.maxLength(300)])],
            "startDate": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
            "endDate": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])]
        });
    }

    private submit(value: any): void {
        event.preventDefault();

        const stage = new Stage();
        stage.name = value.name;
        stage.description = value.description;
        stage.startDate = value.startDate;
        stage.endDate = value.endDate;

        this.service.add(stage).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/stages']);
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
