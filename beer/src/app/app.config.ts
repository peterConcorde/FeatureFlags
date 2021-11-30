
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { IAppConfig } from './app-config.model';


@Injectable()
export class AppConfig {
    static settings: Observable<IAppConfig>;
    constructor(private http: HttpClient) {}
    load() {
        const jsonFile = `assets/config/config.${environment.name}.json`;
        AppConfig.settings =  this.http.get(jsonFile)
            .pipe(
                map(config => <IAppConfig>config),
                tap(config => console.log(`loading config from ${jsonFile}. env:name= ${config.env.name}, punkUrl=${config.urls.punkApiBaseAddress}`)),
               );
    }
}