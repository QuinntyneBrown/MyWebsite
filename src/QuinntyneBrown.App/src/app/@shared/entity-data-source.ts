import { CollectionViewer } from "@angular/cdk/collections";
import { DataSource } from "@angular/cdk/table";
import { IPagableService } from "@core/ipagable-service";
import { replace } from "@core/replace";
import { BehaviorSubject, Observable, Subject } from "rxjs";
import { takeUntil, tap } from "rxjs/operators";

export class EntityDataSource<T> implements DataSource<T> {
    private readonly _disconnected$: Subject<void> = new Subject();

    public entities$: BehaviorSubject<any[]> = new BehaviorSubject([]);
    public length$: BehaviorSubject<number> = new BehaviorSubject(0);

    constructor(
      private readonly _pagableService: IPagableService<T>
      ) {

      }

    public connect(collectionViewer: CollectionViewer): Observable<T[] | readonly T[]> {
      return this.entities$.asObservable();
    }

    public disconnect(collectionViewer: CollectionViewer): void {
      this._disconnected$.next();
      this._disconnected$.complete();
    }

    public update(value: T) {
        this.entities$
        .next(replace({ items: this.entities$.value, value, key: this._pagableService.uniqueIdentifierName }));
    }

    public getPage(options: { pageIndex: number, pageSize: number }) {
        this._pagableService.getPage(options)
        .pipe(
            takeUntil(this._disconnected$),
            tap(x => {
                this.length$.next(x.length);
                this.entities$.next(x.entities)
            })
        ).subscribe();
    }
}

