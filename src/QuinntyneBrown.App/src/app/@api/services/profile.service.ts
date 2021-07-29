import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Profile } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class ProfileService implements IPagableService<Profile> {

  uniqueIdentifierName: string = "profileId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Profile>> {
    return this._client.get<EntityPage<Profile>>(`${this._baseUrl}api/profile/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Profile[]> {
    return this._client.get<{ profiles: Profile[] }>(`${this._baseUrl}api/profile`)
      .pipe(
        map(x => x.profiles)
      );
  }

  public getById(options: { profileId: string }): Observable<Profile> {
    return this._client.get<{ profile: Profile }>(`${this._baseUrl}api/profile/${options.profileId}`)
      .pipe(
        map(x => x.profile)
      );
  }

  public getByName(options: { fullname: string }): Observable<Profile> {
    return this._client.get<{ profile: Profile }>(`${this._baseUrl}api/profile/name/${options.fullname}`)
      .pipe(
        map(x => x.profile)
      );
  }

  public remove(options: { profile: Profile }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/profile/${options.profile.profileId}`);
  }

  public create(options: { profile: Profile }): Observable<{ profile: Profile }> {
    return this._client.post<{ profile: Profile }>(`${this._baseUrl}api/profile`, { profile: options.profile });
  }

  public update(options: { profile: Profile }): Observable<{ profile: Profile }> {
    return this._client.put<{ profile: Profile }>(`${this._baseUrl}api/profile`, { profile: options.profile });
  }
}
