import { Injectable } from "@angular/core";
import { User, UserService } from "@api";
import { switchMapByKey } from "@core/abstractions/switch-map-by-key";
import { ComponentStore } from "@ngrx/component-store";
import { EMPTY, of } from "rxjs";
import { catchError, filter, first, mergeMap, shareReplay, switchMap, tap } from "rxjs/operators";
import { isNonNull } from "@core/abstractions";

export interface UserStoreState {

}

@Injectable({
  providedIn: "root"
})
export class UserStore extends ComponentStore<UserStoreState> {

  constructor(
    private readonly _userService: UserService
  ) {
    super({ })
  }
}
