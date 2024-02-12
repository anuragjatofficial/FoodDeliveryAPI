import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantItemsPageComponent } from './restaurant-items-page.component';

describe('RestaurantItemsPageComponent', () => {
  let component: RestaurantItemsPageComponent;
  let fixture: ComponentFixture<RestaurantItemsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RestaurantItemsPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RestaurantItemsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
