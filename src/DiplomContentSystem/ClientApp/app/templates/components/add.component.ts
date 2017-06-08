import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { TemplateService } from '../templates.service';
import { Template } from '../models/template';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';

@Component({
    selector: 'templates-add',
    templateUrl: './add.component.html'
})
export class TemplatesAddComponent implements OnInit {
    private form: FormGroup;
    private positionOptions:SelectListItem[];
    private departmentOptions:SelectListItem[];
    private errors: string[] = [];

    constructor(private service: TemplateService, private router: Router, private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            "fio": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty(), CustomValidators.wordCount(3)])],
            "maxWorkCount": [undefined, Validators.compose([Validators.required,CustomValidators.minValue(1)])],
            "position": ["", Validators.required],
            "department": ["", Validators.required]
        });
    }
    
    ngOnInit()
    {
    }

    private submit(value: any): void {
        event.preventDefault();

        const template = new Template();
        template.fio = value.fio;
        template.positionId = value.position;
        template.maxWorkCount = value.maxWorkCount;
        template.departmentId = value.department;
        
        this.service.add(template).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/templates']);
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
