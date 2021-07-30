import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RememberMeComponent } from './remember-me.component';

describe('RememberMeComponent', () => {
  let component: RememberMeComponent;
  let fixture: ComponentFixture<RememberMeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RememberMeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RememberMeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
