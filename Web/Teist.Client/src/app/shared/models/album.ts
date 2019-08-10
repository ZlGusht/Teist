import { BaseEntity } from './contracts/base-entity.interface';

export class Album implements BaseEntity {
    id: number;
    name: string;
    genre: string;
    pieces: string;
    performer: string;

    constructor(album: any) {
    this.name = album.name;
    this.genre = album.genre;
    this.pieces = album.pieces;
    this.performer = album.performer;
    }
}
