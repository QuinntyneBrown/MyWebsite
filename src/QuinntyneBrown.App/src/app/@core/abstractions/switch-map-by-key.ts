import { EMPTY, Observable, OperatorFunction } from "rxjs";
import { groupBy, ignoreElements, map, mergeAll, switchMap, timeoutWith } from "rxjs/operators";

export function switchMapByKey<T, V>(
  keySelector: (item: T) => number | string,
  mapFn: (item: T) => Observable<V>
): OperatorFunction<T, V> {
  return observable$ =>
    observable$.pipe(
      groupBy(
        keySelector,
        item => item,
        itemsByGroup$ =>
          itemsByGroup$.pipe(
            timeoutWith(15000, EMPTY),
            ignoreElements()
          )
      ),
      map((itemGroup$: Observable<T>) => itemGroup$.pipe(switchMap(mapFn))),
      mergeAll()
    );
}
