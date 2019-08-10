import { BaseEntity } from './contracts/base-entity.interface';

export class Chart implements BaseEntity {
    id: number;
    name: string;
    type: string;
    description: string;
    contents: string[];

    constructor(chart: any) {
        this.name = chart.name;
        this.type = chart.type;
        this.description = chart.description;
        this.contents = chart.contents;
    }
}