import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DigitalAsset } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class DigitalAssetService implements IPagableService<DigitalAsset> {

  uniqueIdentifierName: string = "digitalAssetId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<DigitalAsset>> {
    return this._client.get<EntityPage<DigitalAsset>>(`${this._baseUrl}api/digitalAsset/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<DigitalAsset[]> {
    return this._client.get<{ digitalAssets: DigitalAsset[] }>(`${this._baseUrl}api/digitalAsset`)
      .pipe(
        map(x => x.digitalAssets)
      );
  }

  public getById(options: { digitalAssetId: string }): Observable<DigitalAsset> {
    return this._client.get<{ digitalAsset: DigitalAsset }>(`${this._baseUrl}api/digitalAsset/${options.digitalAssetId}`)
      .pipe(
        map(x => x.digitalAsset)
      );
  }

  public remove(options: { digitalAsset: DigitalAsset }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/digitalAsset/${options.digitalAsset.digitalAssetId}`);
  }

  public create(options: { digitalAsset: DigitalAsset }): Observable<{ digitalAsset: DigitalAsset }> {
    return this._client.post<{ digitalAsset: DigitalAsset }>(`${this._baseUrl}api/digitalAsset`, { digitalAsset: options.digitalAsset });
  }
  
  public update(options: { digitalAsset: DigitalAsset }): Observable<{ digitalAsset: DigitalAsset }> {
    return this._client.put<{ digitalAsset: DigitalAsset }>(`${this._baseUrl}api/digitalAsset`, { digitalAsset: options.digitalAsset });
  }
}
