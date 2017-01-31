import {AbstractControl, ValidatorFn} from "@angular/forms";
export interface ValidationResult
{
    [key:string]:any;
}
export class CustomValidators
{
    public static notEmpty(): ValidatorFn {
        return (control: AbstractControl): ValidationResult => {
            let v: string = control.value;
            return (!v)||(v.trim()!=='') ? null : {'notEmpty': true};
            };
    }

    public static minValue(min:number): ValidatorFn {
        return (control: AbstractControl): ValidationResult => {
            let v: number = control.value;
            return min<=v ? null : { 'minValue': true };
        };
    }
}