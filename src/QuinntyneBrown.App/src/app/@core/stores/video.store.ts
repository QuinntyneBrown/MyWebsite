import { Injectable } from "@angular/core";
import { Video, VideoService } from "@api";
import { switchMapByKey } from "@core/abstractions/switch-map-by-key";
import { ComponentStore } from "@ngrx/component-store";
import { EMPTY, of } from "rxjs";
import { catchError, filter, first, mergeMap, shareReplay, switchMap, tap } from "rxjs/operators";
import { isNonNull } from "@core/abstractions";

export interface VideoStoreState {
  videos?: Video[],
  video?: Video
}

@Injectable({
  providedIn: "root"
})
export class VideoStore extends ComponentStore<VideoStoreState> {

  constructor(
    private readonly _videoService: VideoService
  ) {
    super({ })
  }

  public getVideos() {
    return of(undefined)
    .pipe(
      tap(_ => this._getVideos()),
      switchMap(_ => this.select(x => x.videos)),
      shareReplay(1)
    )
  }

  public getVideoById(videoId: string) {
    return of(undefined)
    .pipe(
      tap(_ => this._getVideoById(videoId)),
      switchMap(_ => this.select(x => x.video)),
      shareReplay(1)
    );
  }

  private readonly _getVideos = this.effect<void>(trigger$ =>
    trigger$.pipe(
      switchMap(_ => this.select(x => x.videos).pipe(first())
      .pipe(
        switchMap(videos => {
          if(videos === undefined) {
            return this._videoService.get()
            .pipe(
              tap(videos => this.setState((state) => ({...state, videos }))),
            );
          }
          return of(videos);
        }),
        filter(isNonNull)
      ))
    ));

  private _getVideoById = this.effect<string>(videoId$ =>
    videoId$.pipe(
      switchMapByKey(videoId => videoId, videoId => {
        return this.select(x => x.video).pipe(first())
        .pipe(
          switchMap(video => {
            if(video?.videoId == videoId) {
              return of(video);
            }
            return this._videoService.getById({ videoId })
            .pipe(
              tap((video:Video) => this.setState((state) => ({ ...state, video })))
            )
          }),
          filter(isNonNull)
        );
      })
    ))

  readonly createVideo = this.effect<Video>(video$ => video$.pipe(
    mergeMap(video => {
      return this._videoService.create({ video })
      .pipe(
        tap({
          next:({ video }) => {
            this.setState((state) => ({...state, video }))
          },
          error: () => {

          }
        }),
        catchError(() => EMPTY)
      )
    })
  ));

  readonly updateVideo = this.effect<Video>(video$ => video$.pipe(
    mergeMap(video => {
      return this._videoService.update({ video })
      .pipe(
        tap({
          next: ({ video }) => {
            this.setState((state) => ({...state, video }))
          },
          error: () => {

          }
        }),
        catchError(() => EMPTY)
      )
    })
  ));

  readonly removeVideo = this.effect<Video>(video$ => video$.pipe(
    mergeMap(video => {
      return this._videoService.remove({ video })
      .pipe(
        tap({
          next: _ => {
            this.setState((state) => ({...state, video: null }));
          },
          error: () => {

          }
        }),
        catchError(() => EMPTY)
      )
    })
  ));
}
