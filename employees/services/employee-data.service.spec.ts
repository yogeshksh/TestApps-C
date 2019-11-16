import { TestBed, async } from "@angular/core/testing";
import { EmployeeDataService } from "./employee-data.service";
describe("EmployeeDataService", () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [EmployeeDataService]
    }).compileComponents();
  }));
  it("should create the service", async(() => {
    const fixture = TestBed.createComponent(EmployeeDataService);
    const empService = fixture.debugElement.componentInstance;
    expect(empService).toBeTruthy();
  }));
 
});
