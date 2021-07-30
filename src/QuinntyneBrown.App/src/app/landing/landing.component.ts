import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { Video, VideoService } from '@api';
import { baseUrl } from '@core';
import { ShellContextService } from '@shared/shells/shell/shell-context.service';
import { combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent {

  public readonly vm$ = combineLatest([
    this._shellContextService.profile$,
    this._videoService.get()
  ])
  .pipe(
    map(([profile,videos]) => ({ profile, videos }))
  );

  constructor(
    @Inject(baseUrl) public baseUrl:string,
    private readonly _shellContextService: ShellContextService,
    private readonly _videoService: VideoService,
    private readonly _router: Router
  ) { }

  public handleVideoTitleClick(video: Video) {
    this._router.navigate(["player",video.videoId]);
  }
}
