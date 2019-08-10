import { BaseEntity } from './contracts/base-entity.interface';

export class Artist implements BaseEntity {
    id: number;
    nickname: string;
    genre: string;
    firstName: string;
    lastName: string;

    constructor(artist: any) {
    this.nickname = artist.name; 
    this.genre = artist.genre; 
    this.firstName = artist.firstName; 
    this.lastName = artist.lastName; 
    }
}
