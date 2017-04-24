import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { GroupService } from '../group.service';
import { Group } from '../models/group';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';

@Component({
    selector: 'groups-add',
    templateUrl: './add.component.html'
})
export class GroupAddComponent implements OnInit {
    private form: FormGroup;
    private specialityOptions:SelectListItem[];
    private errors: string[] = [];

    constructor(private service: GroupService, private router: Router, private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            "name": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
            "speciality": ["", Validators.required],
        });
    }
    
    ngOnInit()
    {
        this.service.getSpecialities().subscribe(r=>this.specialityOptions = r);
    }

    private submit(value: any): void {
        event.preventDefault();

        const group = new Group();
        group.name = value.fio;
        group.specialityId = value.department;
        
        this.service.add(group).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/groups']);
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
