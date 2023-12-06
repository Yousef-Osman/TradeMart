import { Component } from '@angular/core';

@Component({
  selector: 'app-pagination-header',
  templateUrl: './pagination-header.component.html',
  styleUrl: './pagination-header.component.scss'
})
export class PaginationHeaderComponent {
  currentPage?: number = 1;
  pageSize?: number = 12;
  totalCount?: number = 24;
}
