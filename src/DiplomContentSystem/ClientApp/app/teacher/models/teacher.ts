export class Teacher {
    id: number;
    fio: string;
    position: Position;
    positionId: number;
    specialityId: number;
    maxWorkCount: string;
}
export class Position
{
    id:number;
    name?:string;
}