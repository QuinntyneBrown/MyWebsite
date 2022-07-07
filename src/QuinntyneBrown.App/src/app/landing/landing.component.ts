import { Component, inject, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { Video, VideoService } from '@api';
import { baseUrl } from '@core';
import { ProfileStore } from '@core/services/context/profile-store.service';
import { combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent {

  private readonly _profileStore = inject(ProfileStore);
  private readonly _videoService = inject(VideoService);
  private readonly _router = inject(Router);

  readonly vm$ = combineLatest([
    this._profileStore.profile$,
    this._videoService.get()
  ])
  .pipe(
    map(([profile,videos]) => ({ profile, videos }))
  );

  constructor(
    @Inject(baseUrl) public baseUrl:string,
  ) { }

  handleVideoTitleClick(video: Video) {
    this._router.navigate(["player",video.videoId]);
  }
}
