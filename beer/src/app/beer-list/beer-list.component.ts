import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { AppConfig } from '../app.config';
import { BeerItem } from '../models/beer-item';
import { PunkService } from '../services/punk.service';

@Component({
  selector: 'app-beer-list',
  templateUrl: './beer-list.component.html',
  styleUrls: ['./beer-list.component.css']
})
export class BeerListComponent implements OnInit {

  beers: any[] = []
  totalPaginationLength = 50;
  private readonly PAGE_SIZE = 10;
  displayedColumns = ['Name', 'Tagline', 'FirstBrewed', 'Abv']
  constructor(private punkService : PunkService) {}
  
  ngOnInit(): void {
    this.fetchPage(1,this.PAGE_SIZE);
  }

  private fetchPage(page: number, size: number){
    this.punkService.getBeer(page, size).subscribe(res => {
      this.beers = res;
    });
  }

  paginate(event : PageEvent) {
    this.fetchPage(event.pageIndex, event.pageSize);

    if (this.totalPaginationLength <= ((event.pageIndex + 1)*event.pageSize))
    {
      this.totalPaginationLength += 10
    }
  }

}
