import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IPagination } from '../../interfaces/ipagination';

@Component({
  selector: 'app-pagination-footer',
  templateUrl: './pagination-footer.component.html',
  styleUrl: './pagination-footer.component.scss'
})
export class PaginationFooterComponent {
  @Input() pagination!: IPagination;
  @Output() pageNumberEmitter = new EventEmitter<number>();

  onPageChanged(){
    this.pageNumberEmitter.emit(this.pagination?.currentPage);
  }
}
