import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Talk } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class TalkService implements IPagableService<Talk> {

  uniqueIdentifierName: string = "talkId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Talk>> {
    return this._client.get<EntityPage<Talk>>(`${this._baseUrl}api/talk/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Talk[]> {
    return this._client.get<{ talks: Talk[] }>(`${this._baseUrl}api/talk`)
      .pipe(
        map(x => x.talks)
      );
  }

  public getById(options: { talkId: string }): Observable<Talk> {
    return this._client.get<{ talk: Talk }>(`${this._baseUrl}api/talk/${options.talkId}`)
      .pipe(
        map(x => x.talk)
      );
  }

  public remove(options: { talk: Talk }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/talk/${options.talk.talkId}`);
  }

  public create(options: { talk: Talk }): Observable<{ talk: Talk }> {
    return this._client.post<{ talk: Talk }>(`${this._baseUrl}api/talk`, { talk: options.talk });
  }
  
  public update(options: { talk: Talk }): Observable<{ talk: Talk }> {
    return this._client.put<{ talk: Talk }>(`${this._baseUrl}api/talk`, { talk: options.talk });
  }
}
