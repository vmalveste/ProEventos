import { EventoService } from './../services/evento.service';
import { Evento } from './../models/Evento';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: Evento[] = [];
  public filteredEventos: any = [];

  public widhthImg = 150;
  public marginImg = 2;
  public showImg = true;
  private filtroListado: string = '';

  public get filterList(): string {
    return this.filtroListado;
  }

  public set filterList(value) {
    this.filtroListado = value;
    this.filteredEventos = this.filterList
      ? this.filterEventos(this.filterList)
      : this.eventos;
  }

  public filterEventos(filterBy: string): Evento[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) =>
        evento.tema.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        evento.lote.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(private eventoService: EventoService) {}

  public ngOnInit() {
    this.getEventos();
  }
  public hideImg(): void {
    this.showImg = !this.showImg;
  }

  public getEventos(): void {
    const observer = {
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.filteredEventos = this.eventos;
      },
      error: (error: any) => console.log(error),
    };

    this.eventoService.getEventos().subscribe(observer);
  }
}
