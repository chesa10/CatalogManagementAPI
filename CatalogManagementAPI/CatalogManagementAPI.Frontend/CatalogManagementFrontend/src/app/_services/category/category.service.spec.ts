import { TestBed } from '@angular/core/testing';
import { HttpTestingController, provideHttpClientTesting } from '@angular/common/http/testing';
import { config } from 'src/app/Config/Config';

import { environment } from 'src/app/Environments/environment';

const endpoints = config.endpoints;
import { CategoryService } from './category.service';

describe('CategoryService', () => {
  let service: CategoryService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        CategoryService,
        provideHttpClient(),
        provideHttpClientTesting(), // Mock backend
      ]});
    service = TestBed.inject(CategoryService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

   it('should fetch categories via GET', () => {
    const mockCategories= [{ id: 1, name: 'Electronics', description: "",parentCategoryId: null,children: []}];

    service.GetAllCategories().subscribe(cats => {
      expect(cats).toEqual(mockCategories);
    });

    const req = httpTestingController.expectOne(environment.API_BASE + endpoints.GET_ALL_Categories);
    expect(req.request.method).toEqual('GET');
    req.flush(mockCategories); // Fulfill the request with mock data
  });

  afterEach(() => {
    httpTestingController.verify(); // Ensure no outstanding requests
  });
});
