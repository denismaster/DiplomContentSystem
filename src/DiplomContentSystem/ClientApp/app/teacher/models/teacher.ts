export class Teacher {
    id: number;
    fio: string;
    position: Position;
    positionId: number;
    departmentId: number;
    maxWorkCount: string;
}
export class Position
{
    id:number;
    name?:string;
}