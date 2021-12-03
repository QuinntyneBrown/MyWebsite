export type ActionType = 'select' | 'create' | 'update' | 'delete' | 'cancel' | 'default';

export type Action<T> = {
  type: ActionType,
  payload: T
}
