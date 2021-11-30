import { Injectable } from '@angular/core';
import { BeerItem } from '../models/beer-item';
import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';
import { config, Observable } from 'rxjs';
import { map, retry, switchMap, tap } from 'rxjs/operators';
import { AppConfig } from '../app.config';
import { IAppConfig } from '../app-config.model';

@Injectable({
  providedIn: 'root'
})
export class PunkService {

  constructor(private http: HttpClient) { }

  getBeer(pageNumber :number, pageSize : number) : Observable<BeerItem[]>{
    console.log(`Getting beer from`);

    return AppConfig.settings.pipe(
      tap(config => console.log(`Getting beer from ${config.urls.punkApiBaseAddress}`)),
      switchMap(config => {
        const httpParms = new HttpParams()
          .append('page', `${pageNumber}`)
          .append('per_page', `${pageSize}`);
        console.log(httpParms)
        return this.http.get<BeerItem[]>(config.urls.punkApiBaseAddress,{params : httpParms});
      })   
    );
  }
}
