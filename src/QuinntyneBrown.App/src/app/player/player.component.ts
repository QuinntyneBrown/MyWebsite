import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { VideoService } from '@api';
import { map, switchMap, tap } from 'rxjs/operators';

let apiLoaded = false;

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.scss']
})
export class PlayerComponent implements OnInit {

  public vm$ = this._activatedRoute.paramMap
  .pipe(
    tap(x => console.log(this._activatedRoute.snapshot.params)),
    switchMap(paramMap => this._videoService.getById({ videoId: paramMap.get("videoId")})),
    map(video => ({ video }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _videoService: VideoService
  ) { }

  ngOnInit(): void {
    if (!apiLoaded) {
      const tag = document.createElement('script');
      tag.src = 'https://www.youtube.com/iframe_api';
      document.body.appendChild(tag);
      apiLoaded = true;
    }
  }
}
