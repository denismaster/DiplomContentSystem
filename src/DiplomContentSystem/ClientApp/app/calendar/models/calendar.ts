export class CalendarEvent {
    id: number;
    name:string
    period: string;
    speciality: string;
    specialityId:number;
    studentsCount:number;

    startDate: Date;
    endDate:Date;
    isGlobal: boolean
}