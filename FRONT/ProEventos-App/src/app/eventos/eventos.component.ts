import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  public filteredEventos: any = [];
  widhthImg: number = 150;
  marginImg: number = 2;
  borderRadius: number = 10;
  showImg: boolean = true;
  private _filterList: string = '';

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList(value) {
    this._filterList = value;
    this.filteredEventos = this.filterList ? this.filterEventos(this.filterList) : this.eventos;
  }

  filterEventos(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) =>
      evento.tema.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      evento.lote.toLocaleLowerCase().indexOf(filterBy) !== -1
      );
  }

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getEventos();
  }
  hideImg() {
    this.showImg = !this.showImg;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      (response) => {
        this.eventos = response;
        this.filteredEventos = this.eventos
      },
      (error) => console.log(error)
    );
  }
}
