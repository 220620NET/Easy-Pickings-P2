import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDiscussionComponent } from './show-discussion.component';

describe('ShowDiscussionComponent', () => {
  let component: ShowDiscussionComponent;
  let fixture: ComponentFixture<ShowDiscussionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDiscussionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowDiscussionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
