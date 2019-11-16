import { TestBed, async } from "@angular/core/testing";
import { EmployeesListComponent } from "./employees-list.component";
describe("EmployeesListComponent", () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [EmployeesListComponent]
    }).compileComponents();
  }));
  it("should create the EmployeesListComponent", async(() => {
    const fixture = TestBed.createComponent(EmployeesListComponent);
    const empListComp = fixture.debugElement.componentInstance;
    expect(empListComp).toBeTruthy();
  }));
  it(`should have as list of employee`, async(() => {
    const fixture = TestBed.createComponent(EmployeesListComponent);
    const empListComp = fixture.debugElement.componentInstance;
    expect(empListComp.employees).toEqual("5");
  }));
});
