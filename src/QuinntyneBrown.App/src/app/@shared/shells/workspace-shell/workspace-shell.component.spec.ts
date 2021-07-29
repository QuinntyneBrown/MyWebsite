import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkspaceShellComponent } from './workspace-shell.component';

describe('WorkspaceShellComponent', () => {
  let component: WorkspaceShellComponent;
  let fixture: ComponentFixture<WorkspaceShellComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WorkspaceShellComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkspaceShellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
