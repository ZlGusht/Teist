import { BaseEntity } from './contracts/base-entity.interface';

export class Review implements BaseEntity {
    id: number;
    name: string;
    contents: string;
    type: string;
    description: string;

    constructor(chart: any) {
        this.id = chart.id;
        this.name = chart.name;
        this.contents = chart.contents;
        this.type = chart.type;
        this.description = chart.description;
    }
}