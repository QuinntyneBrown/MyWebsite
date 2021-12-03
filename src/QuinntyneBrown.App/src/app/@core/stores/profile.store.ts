import { Injectable } from "@angular/core";
import { Profile, ProfileService } from "@api";
import { isNonNull } from "@core/abstractions";
import { switchMapByKey } from "@core/abstractions/switch-map-by-key";
import { ComponentStore } from "@ngrx/component-store";
import { EMPTY, of } from "rxjs";
import { catchError, filter, first, mergeMap, shareReplay, switchMap, tap } from "rxjs/operators";



export interface ProfileStoreState {
  profiles?: Profile[],
  profile?: Profile
}

@Injectable({
  providedIn: "root"
})
export class ProfileStore extends ComponentStore<ProfileStoreState> {

  constructor(
    private readonly _profileService: ProfileService
  ) {
    super({ })
  }

  public getProfiles() {
    return of(undefined)
    .pipe(
      tap(_ => this._getProfiles()),
      switchMap(_ => this.select(x => x.profiles)),
      shareReplay(1)
    )
  }

  public getProfileById(profileId: string) {
    return of(undefined)
    .pipe(
      tap(_ => this._getProfileById(profileId)),
      switchMap(_ => this.select(x => x.profile)),
      shareReplay(1)
    );
  }

  private readonly _getProfiles = this.effect<void>(trigger$ =>
    trigger$.pipe(
      switchMap(_ => this.select(x => x.profiles).pipe(first())
      .pipe(
        switchMap(profiles => {
          if(profiles === undefined) {
            return this._profileService.get()
            .pipe(
              tap(profiles => this.setState((state) => ({...state, profiles }))),
            );
          }
          return of(profiles);
        }),
        filter(isNonNull)
      ))
    ));

  private _getProfileById = this.effect<string>(profileId$ =>
    profileId$.pipe(
      switchMapByKey(profileId => profileId, profileId => {
        return this.select(x => x.profile).pipe(first())
        .pipe(
          switchMap(profile => {
            if(profile?.profileId == profileId) {
              return of(profile);
            }
            return this._profileService.getById({ profileId })
            .pipe(
              tap((profile:Profile) => this.setState((state) => ({ ...state, profile })))
            )
          }),
          filter(isNonNull)
        );
      })
    ))

  readonly createProfile = this.effect<Profile>(profile$ => profile$.pipe(
    mergeMap(profile => {
      return this._profileService.create({ profile })
      .pipe(
        tap({
          next:({ profile }) => {
            this.setState((state) => ({...state, profile }))
          },
          error: () => {

          }
        }),
        catchError(() => EMPTY)
      )
    })
  ));

  readonly updateProfile = this.effect<Profile>(profile$ => profile$.pipe(
    mergeMap(profile => {
      return this._profileService.update({ profile })
      .pipe(
        tap({
          next: ({ profile }) => {
            this.setState((state) => ({...state, profile }))
          },
          error: () => {

          }
        }),
        catchError(() => EMPTY)
      )
    })
  ));

  readonly removeProfile = this.effect<Profile>(profile$ => profile$.pipe(
    mergeMap(profile => {
      return this._profileService.remove({ profile })
      .pipe(
        tap({
          next: _ => {
            this.setState((state) => ({...state, profile: null }));
          },
          error: () => {

          }
        }),
        catchError(() => EMPTY)
      )
    })
  ));
}
