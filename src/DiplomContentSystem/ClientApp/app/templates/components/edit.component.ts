import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { TemplateService } from '../templates.service';
import { Template } from '../models/template';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';

@Component({
    selector: 'templates-edit',
    templateUrl: './edit.component.html'
})
export class TemplatesEditComponent implements OnInit {
    private form: FormGroup;
    private errors: string[] = [];

    private positionOptions:SelectListItem[];
    private departmentOptions:SelectListItem[];
    private id:number;
    private template: Template;
    private isLoading:boolean=true;

    constructor(private service: TemplateService, private router: Router, private activatedRoute:ActivatedRoute, private formBuilder: FormBuilder) {
        this.id = activatedRoute.snapshot.params['id'];
        if(!this.id){
            router.navigateByUrl("['/404']");
        }
        this.service.getOne(this.id)
            .subscribe(result=>{
                this.isLoading=false;
                this.form = this.formBuilder.group({
                    "fio": [result.fio, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
                    "maxWorkCount": [result.maxWorkCount, Validators.compose([Validators.required,CustomValidators.minValue(1)])],
                    "position": [result.position.id, Validators.required],
                    "department":[result.departmentId, Validators.required]
                });        
            })
    }

    ngOnInit()
    {
        this.form = this.formBuilder.group({
                    "fio": [undefined],
                    "maxWorkCount": [undefined],
                    "position": [undefined],
                    "department":[undefined]
                });   
    }

    private submit(value: any): void {
        event.preventDefault();

        const template = new Template();
        template.id = this.id;
        template.fio = value.fio;
        template.positionId = value.position;
        template.maxWorkCount = value.maxWorkCount;
        template.departmentId = value.department;
        
        this.service.update(template).subscribe(result=>this.checkResult(result));
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
