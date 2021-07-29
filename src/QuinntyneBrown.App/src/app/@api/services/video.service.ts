import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Video } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class VideoService implements IPagableService<Video> {

  uniqueIdentifierName: string = "videoId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Video>> {
    return this._client.get<EntityPage<Video>>(`${this._baseUrl}api/video/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Video[]> {
    return this._client.get<{ videos: Video[] }>(`${this._baseUrl}api/video`)
      .pipe(
        map(x => x.videos)
      );
  }

  public getById(options: { videoId: string }): Observable<Video> {
    return this._client.get<{ video: Video }>(`${this._baseUrl}api/video/${options.videoId}`)
      .pipe(
        map(x => x.video)
      );
  }

  public remove(options: { video: Video }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/video/${options.video.videoId}`);
  }

  public create(options: { video: Video }): Observable<{ video: Video }> {
    return this._client.post<{ video: Video }>(`${this._baseUrl}api/video`, { video: options.video });
  }
  
  public update(options: { video: Video }): Observable<{ video: Video }> {
    return this._client.put<{ video: Video }>(`${this._baseUrl}api/video`, { video: options.video });
  }
}
