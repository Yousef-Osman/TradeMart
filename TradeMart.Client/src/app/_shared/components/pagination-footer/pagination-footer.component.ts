import { Component } from '@angular/core';

@Component({
  selector: 'app-pagination-footer',
  templateUrl: './pagination-footer.component.html',
  styleUrl: './pagination-footer.component.scss'
})
export class PaginationFooterComponent {
  pagination: any = {
    totalCount: 24,
    currentPage: 1,
    pageSize: 12,
  }

  onPageChanged(){
    
  }
}
